using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frigate.Infrastructure.DbImplementation.Models
{
    [Table(name: "datasourcedetail_table")]
    public  class DataSourceDetails
    {
        [Column(name: "DataSourceDetail_table_id")]
        public int Id { get; set; }
        [Column(name: "DataSourceDetail_table_ConnectionName")]
        public string ConnectionName { get; set; }
        [Column(name: "DataSourceDetail_table_ConnectionString")]
        public string ConnectionString { get; set; }
        [Column(name: "DataSourceDetail_table_IsActive")]
        public bool IsActive { get; set; }
        [Column(name: "DataSourceDetail_table_CreatedBy")]
        public string CreatedBy { get; set; }
        [Column(name: "DataSourceDetail_table_ModifyBy")]
        public string ModifyBy { get; set; }
    }
}
