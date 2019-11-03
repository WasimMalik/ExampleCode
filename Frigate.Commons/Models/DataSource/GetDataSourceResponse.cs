using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Commons.Models.DataSource
{
   public class GetDataSourceResponse
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string ConnectionString { get; set; }
        public string ConnectionType { get; set; }       
        public bool IsDeleted { get; set; }
    }
}
