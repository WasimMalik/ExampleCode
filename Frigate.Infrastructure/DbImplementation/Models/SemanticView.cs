using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frigate.Infrastructure.DbImplementation.Models
{
    [Table(name:"semantic_view")]
    public class SemanticView
    {
        [Column(name:"semantic_view_id")]
        public int dashboardId { get; set; }

        [Column(name:"semantic_view_name")]
        public string SemanticViewName { get; set; }

        [Column(name:"is_active")]
        public bool IsActive { get; set; }

        [Column(name:"created_by")]
        public int CreatedBy { get; set; }

        [Column(name:"created_on")]
        public DateTime CreatedOn { get; set; }

        [Column(name:"modified_by")]
        public int ModifiedBy { get; set; }

        [Column(name:"modified_on")]
        public DateTime ModifiedOn { get; set; }
    }
}
