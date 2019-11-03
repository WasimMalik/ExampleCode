using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Commons.Models.DataSource
{
   public class CreateDataSourceResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ConnectionString { get; set; }
        public string ConnectionType { get; set; }
      
    }
}
