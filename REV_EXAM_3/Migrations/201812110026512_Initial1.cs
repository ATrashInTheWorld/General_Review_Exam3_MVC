namespace REV_EXAM_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBFirstDemo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        value1 = c.String(),
                        value2 = c.Int(nullable: false),
                        value4 = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DBFirstDemo");
        }
    }
}
