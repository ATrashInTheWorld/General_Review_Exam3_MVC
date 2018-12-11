namespace REV_EXAM_3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DUNNO : DbContext
    {
        public DUNNO()
            : base("name=DUNNO")
        {
        }

        public virtual DbSet<DBFirstDemo> DBFirstDemoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
