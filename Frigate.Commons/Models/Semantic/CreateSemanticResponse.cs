using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frigate.Commons.Models.Semantic
{
    public class CreateSemanticResponse
    {
        public int SemanticId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
