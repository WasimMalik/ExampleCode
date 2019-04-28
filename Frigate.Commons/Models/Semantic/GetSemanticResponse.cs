using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Commons.Models.Semantic
{
    public class GetSemanticResponse
    {
        public bool Success { get; set; }
        public int dashboardId { get; set; }
        public string name { get; set; }
        public int Parent { get; set; }
        public bool IsFolder { get; set; }
        public bool IsDeleted { get; set; }
        public List<SemanticTableObject> widgets { get; set; }
    }
}
