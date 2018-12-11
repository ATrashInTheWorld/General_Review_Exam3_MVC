namespace REV_EXAM_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBFirstDemo")]
    public partial class DBFirstDemo
    {
        [Key]
        public int Id { get; set; }

        public string value1 { get; set; }

        public int value2 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime value4 { get; set; }
    }
}
