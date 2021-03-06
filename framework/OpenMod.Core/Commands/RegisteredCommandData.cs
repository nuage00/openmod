﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using OpenMod.API.Prioritization;

namespace OpenMod.Core.Commands
{
    [Serializable]
    public class RegisteredCommandData
    {
        public string Id { get; set; }

        [CanBeNull]
        public string ParentId { get; set; }

        public string Name { get; set; }

        public List<string> Aliases { get; set; }

        public bool Enabled { get; set; }

        public Dictionary<string, object> Data { get; set; }

        public Priority? Priority { get; set; }
    }
}