# OpenMod [![Discord](https://img.shields.io/discord/666327627124047872?label=Discord )](https://discord.com/invite/jRrCJVm)

OpenMod is a plugin framework for .NET. 

It supports authorization, plugin configurations, internalization, command handling and much more. OpenMod can be used for games, bot frameworks, web servers or anything else and has official implementations for Unturned, Rust (WIP) and a standalone console.

For a list of available plugins, visit [openmod-plugins](https://github.com/openmod/openmod-plugins).

## Features
OpenMod is based on modern C# code and best practices.
- Modern API for plugin development with C# and Unity best practices
- Plugin installation with [NuGet](https://nuget.org)
- Can self update with NuGet
- Based on [.NET Generic Host](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host)
- IoC and Dependency Injection using Autofac
- Configure OpenMod and plugins with yaml configurations, environment variables, commandline arguments, etc.
- Serilog for logging, including rich configuration options via logging.yml

## Getting Started
To get started, visit the [OpenMod Documentation](https://openmod.github.io/openmod-docs/).

If you would like to install OpenMod, installation guides for the following platforms are available:
- [Unturned](https://openmod.github.io/openmod-docs/user-guide/installation/unturned/)

If you want to make plugins for OpenMod, you can get started by reading the [Making your first plugin](https://openmod.github.io/openmod-docs/development-guide/making-your-first-plugin/) page.

## Supported Games
Currently Unturned is the only supported game. More games might follow in the future.

## Supported Unturned Modules

- RocketMod 4

A RocketMod 4 bridge has been made, which allows to run legacy RM4 plugins.
   - The configs for RM4 are yet to be decided to be separate, or to be proxied.

A RocketMod 4 Permissions Link has been made too, which allows to use RM4 permissions.
   - The permissions for RM4 are yet to be decided to be separate, or to be proxied.

## Build Status
| **framework**                                                                                                                                                                          | standalone                                                                                                                                                                       | unityengine                                                                                                                                                                         | unturned                                                                                                                                                                                        |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [![OpenMod.Bootstrapper](https://github.com/openmod/OpenMod/workflows/OpenMod.Bootstrapper/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Bootstrapper) | [![OpenMod.Standalone](https://github.com/openmod/OpenMod/workflows/OpenMod.Standalone/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Standalone) | [![OpenMod.UnityEngine](https://github.com/openmod/OpenMod/workflows/OpenMod.UnityEngine/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.UnityEngine) | [![OpenMod.Unturned](https://github.com/openmod/OpenMod/workflows/OpenMod.Unturned/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Unturned)                      |
| [![OpenMod.API](https://github.com/openmod/OpenMod/workflows/OpenMod.API/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.API)                            |                                                                                                                                                                                  |                                                                                                                                                                                     | [![OpenMod.Unturned.Module](https://github.com/openmod/OpenMod/workflows/OpenMod.Unturned.Module/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Unturned.Module) |
| [![OpenMod.Core](https://github.com/openmod/OpenMod/workflows/OpenMod.Core/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Core)                         |                                                                                                                                                                                  |                                                                                                                                                                                     | [![OpenMod.Rocket.API](https://github.com/openmod/OpenMod/workflows/OpenMod.Rocket.API/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Rocket.API)                |
| [![OpenMod.NuGet](https://github.com/openmod/OpenMod/workflows/OpenMod.NuGet/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.NuGet)                      |                                                                                                                                                                                  |                                                                                                                                                                                     | [![OpenMod.Rocket.Core](https://github.com/openmod/OpenMod/workflows/OpenMod.Rocket.Core/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Rocket.Core)             |
| [![OpenMod.Runtime](https://github.com/openmod/OpenMod/workflows/OpenMod.Runtime/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Runtime)                |                                                                                                                                                                                  |                                                                                                                                                                                     | [![OpenMod.Rocket.Unturned](https://github.com/openmod/OpenMod/workflows/OpenMod.Rocket.Unturned/badge.svg)](https://github.com/openmod/OpenMod/actions?query=workflow%3AOpenMod.Rocket.Unturned) |
