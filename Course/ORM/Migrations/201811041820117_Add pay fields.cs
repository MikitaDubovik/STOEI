namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpayfields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ages",
                c => new
                    {
                        AgeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AgeId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        SexId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SexId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sexes");
            DropTable("dbo.Languages");
            DropTable("dbo.Ages");
        }
    }
}
