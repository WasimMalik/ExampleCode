using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frigate.Infrastructure.DbImplementation.Models
{
    [Table(name:"test_table")]
    public class TestTable
    {
        [Column(name:"test_table_id")]
        public int TestTableId { get; set; }

        [Column(name:"test_table_data")]
        public string TestTableData { get; set; }
    }
}
