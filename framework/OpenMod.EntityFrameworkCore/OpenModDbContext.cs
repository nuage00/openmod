﻿using System;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenMod.API.Plugins;

namespace OpenMod.EntityFrameworkCore
{
    public abstract class OpenModDbContext<TSelf> : DbContext where TSelf : OpenModDbContext<TSelf>
    {
        private readonly IServiceProvider m_ServiceProvider;
        private readonly ILogger<TSelf> m_Logger;

        public virtual string MigrationsTableName
        {
            get
            {
                var componentId = GetType().Assembly.GetCustomAttribute<PluginMetadataAttribute>().Id;
                return "__" + componentId.Replace(".", "_") + "_MigrationsHistory".ToLower();
            }
        }

        public virtual string TablePrefix
        {
            get
            {
                var componentId = GetType().Assembly.GetCustomAttribute<PluginMetadataAttribute>().Id;
                return componentId.Replace(".", "_") + "_";
            }
        }

        protected OpenModDbContext(IServiceProvider serviceProvider)
        {
            m_ServiceProvider = serviceProvider;
            m_Logger = serviceProvider.GetRequiredService<ILogger<TSelf>>();
        }

        protected OpenModDbContext([NotNull] DbContextOptions<TSelf> options, IServiceProvider serviceProvider) :
            base(options)
        {
            m_ServiceProvider = serviceProvider;
            m_Logger = serviceProvider.GetRequiredService<ILogger<TSelf>>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var connectionStringName = GetConnectionStringName();
            var connectionStringAccessor = m_ServiceProvider.GetRequiredService<IConnectionStringAccessor>();
            var connectionString = connectionStringAccessor.GetConnectionString(connectionStringName);

            optionsBuilder.UseMySQL(connectionString,
                options => { options.MigrationsHistoryTable(MigrationsTableName); });
        }

        protected virtual string GetConnectionStringName()
        {
            return typeof(TSelf).GetCustomAttribute<ConnectionStringAttribute>()?.Name ??
                ConnectionStrings.Default;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyTableNameConvention(modelBuilder);
        }

        protected virtual void ApplyTableNameConvention(ModelBuilder modelBuilder)
        {
            if (string.IsNullOrEmpty(TablePrefix))
            {
                return;
            } 

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var name = TablePrefix + entityType.GetTableName();
                m_Logger.LogDebug($"Applying table name convention: {entityType.GetTableName()} -> {name}");
                entityType.SetTableName(name);
            }
        }
    }
}