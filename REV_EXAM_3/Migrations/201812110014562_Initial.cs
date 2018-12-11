namespace REV_EXAM_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DBFirstDemo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DBFirstDemo",
                c => new
                    {
                        SomeId = c.Int(nullable: false),
                        value1 = c.String(),
                        value2 = c.Int(nullable: false),
                        value4 = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.SomeId);
            
        }
    }
}
