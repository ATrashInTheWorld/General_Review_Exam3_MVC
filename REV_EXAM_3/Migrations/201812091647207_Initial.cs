namespace REV_EXAM_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasicDemoClasses",
                c => new
                    {
                        myPk = c.Int(nullable: false, identity: true),
                        name1 = c.String(),
                        randomeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.myPk);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BasicDemoClasses");
        }
    }
}
