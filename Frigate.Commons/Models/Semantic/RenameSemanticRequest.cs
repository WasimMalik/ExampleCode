﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frigate.Commons.Models.Semantic
{
    public class RenameSemanticRequest
    {
        public int DashboardId { get; set; }
        public string Name { get; set; }
    }
}