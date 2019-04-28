using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frigate.Infrastructure.DbImplementation.Models
{
    [Table(name:"semantic_view_details")]
    public class SemanticViewDetails
    {
        [Column(name:"semantic_view_details_id")]
        public long SemanticViewDetailsId { get; set; }

        [Column(name:"semantic_view_id")]
        public int SemanticViewId { get; set; }

        [Column(name:"table_name")]
        public string TableName { get; set; }

        [Column(name:"semantic_column_name")]
        public string SemanticColumnName { get; set; }
        
        [Column(name: "semantic_column_alias")]
        public string SemanticColumnAlias { get; set; }

        [Column(name:"semantic_column_description")]
        public string SemanticColumnDescription { get; set; }

        [Column(name:"semantic_column_type")]
        public string SemanticColumnType { get; set; }
    }
}
