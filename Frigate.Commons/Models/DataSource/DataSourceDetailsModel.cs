using System;
using System.Collections.Generic;
using System.Text;

namespace Frigate.Commons.Models.DataSource
{
  public  class DataSourceDetailsModel
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; }
        public string ConnectionType { get; set; }
        public IList<DataSourceDetailsModel> DataSourceTableObj { get; set; }
    }
}
