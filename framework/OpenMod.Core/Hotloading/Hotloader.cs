using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using OpenMod.Core.Helpers;

namespace OpenMod.Core.Hotloading
{
    public static class Hotloader
    {
        private static readonly Dictionary<string, Assembly> s_Assemblies;

        static Hotloader()
        {
            s_Assemblies = new Dictionary<string, Assembly>();
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        }

        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var expectedName = ReflectionExtensions.GetVersionIndependentName(args.Name, out _);
            if (s_Assemblies.TryGetValue(expectedName, out var assembly))
            {
                return assembly;
            }

            Version higestVersion = null;
            foreach (var currentAssembly in s_Assemblies.Values)
            {
                var assemblyName = ReflectionExtensions.GetVersionIndependentName(currentAssembly.FullName, out _);
                if (!assemblyName.Equals(expectedName))
                {
                    continue;
                }

                var currentVersion = currentAssembly.GetName().Version;
                if (higestVersion != null && higestVersion > currentVersion)
                {
                    continue;
                }

                assembly = currentAssembly;
                higestVersion = currentVersion;
            }

            if (assembly != null)
            {
                s_Assemblies.Add(expectedName, assembly);
            }

            return assembly;
        }

        public static Assembly LoadAssembly(byte[] assemblyData)
        {
            using var input = new MemoryStream(assemblyData, writable: false);
            using var output = new MemoryStream();

            var modCtx = ModuleDef.CreateModuleContext();
            var module = ModuleDefMD.Load(input, modCtx);

            var realFullname = module.Assembly.FullName;
            s_Assemblies.Remove(realFullname);

            var guid = Guid.NewGuid().ToString("N").Substring(startIndex: 0, length: 6); //Format "N" already removes '-' from guid
            var name = $"{module.Assembly.Name}-{guid}";

            module.Assembly.Name = name;
            module.Assembly.PublicKey = null;
            module.Assembly.HasPublicKey = false;

            module.Write(output);
            //output.Seek(offset: 0, SeekOrigin.Begin); -> MemoryStream.ToArray does not need seek

            var newAssemblyData = output.ToArray();
            var assembly = Assembly.Load(newAssemblyData);
            s_Assemblies.Add(realFullname, assembly);
            return assembly;
        }

        public static void Remove(Assembly assembly)
        {
            foreach (var kv in s_Assemblies.Where(kv => kv.Value == assembly))
            {
                s_Assemblies.Remove(kv.Key);
            }
        }

        public static Assembly GetAssembly(string fullname)
        {
            return s_Assemblies[fullname];
        }

        public static IReadOnlyCollection<Assembly> GetHotloadedAssemblies()
        {
            return s_Assemblies.Values;
        }

        public static AssemblyName GetRealName(Assembly assembly)
        {
            foreach (var kv in s_Assemblies.Where(kv => kv.Value == assembly))
            {
                return new AssemblyName(kv.Key);
            }

            return assembly.GetName();
        }
    }
}