﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using OpenMod.API;
using OpenMod.API.Prioritization;

namespace OpenMod.Core.Commands.OpenModCommands
{
    [Command("openmod", Priority = Priority.Highest)]
    [CommandAlias("om")]
    [CommandDescription("Get information about OpenMod and manage it")]
    [CommandSyntax("[<install/uninstall/update/reload>]")]
    public class CommandOpenMod : Command
    {
        private readonly IRuntime m_Runtime;
        private readonly IOpenModHost m_Host;
        private readonly IHostInformation m_HostInformation;

        public CommandOpenMod(IRuntime runtime, IOpenModHost host, IHostInformation hostInformation, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Runtime = runtime;
            m_Host = host;
            m_HostInformation = hostInformation;
        }

        protected override async Task OnExecuteAsync()
        {
            await Context.Actor.PrintMessageAsync($"OpenMod v{m_Runtime.Version} (c) Enes Sadık Özbek and contributors", Color.Green);
            await Context.Actor.PrintMessageAsync("OpenMod is free and open source, licensed under the EUPL-1.2.", Color.Green);
            await Context.Actor.PrintMessageAsync("Downloads and source code available at https://github.com/openmod/openmod.", Color.Green);
            await Context.Actor.PrintMessageAsync($"Host: {m_HostInformation.HostName} v{m_HostInformation.HostVersion}", Color.Green);
        }
    }
}