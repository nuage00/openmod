﻿using System;
using System.IO;
using OpenMod.Bootstrapper;
using OpenMod.NuGet;
using Oxide.Core;
using Oxide.Core.Extensions;
using OxideExtension = Oxide.Core.Extensions.Extension;

namespace OpenMod.Rust.Oxide.Extension
{
    public class OpenModRustOxideExtension : OxideExtension
    {
        public OpenModRustOxideExtension(ExtensionManager manager) : base(manager)
        {
            var assemblyVersion = GetType().Assembly.GetName().Version;
            Version = new VersionNumber(assemblyVersion.Major, assemblyVersion.Minor, assemblyVersion.Build);
        }

        public override void Load()
        {
            var openModDirectory = Path.Combine(Interface.Oxide.RootDirectory, "openmod");
            if (!Directory.Exists(openModDirectory))
            {
                Directory.CreateDirectory(openModDirectory);
            }

            var bootrapper = new OpenModDynamicBootstrapper();

            OpenModRuntime = bootrapper.Bootstrap(
                openModDirectory,
                Environment.GetCommandLineArgs(),
                new[] { "OpenMod.UnityEngine", "OpenMod.Rust", "OpenMod.Rust.Oxide" },
                new[] { "OpenMod.Rust.Redist", "OpenMod.UnityEngine.Redist", "OpenMod.Rust.Oxide.Redist" },
                allowPrereleaseVersions: false,
                new NuGetConsoleLogger());
        }

        public object OpenModRuntime { get; private set; }

        public override string Name { get; } = "OpenMod for Rust OxideMod";

        public override string Author { get; } = "OpenMod Contributors";

        public override VersionNumber Version { get; }
    }
}
