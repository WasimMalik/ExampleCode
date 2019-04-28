using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frigate.Commons.Models.Semantic
{
    public class CreateSemanticViewDetailsRequest
    {
        public int SemanticId { get; set; }
        public string TableName { get; set; }
        public string Semanticname  { get; set; }
    public IList<SemanticTableObject> SemanticTableObj { get; set; }
    }
}
