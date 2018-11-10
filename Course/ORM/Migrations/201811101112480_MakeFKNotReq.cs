namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeFKNotReq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "AgeId", "dbo.Ages");
            DropForeignKey("dbo.Posts", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Posts", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Posts", "SexId", "dbo.Sexes");
            DropIndex("dbo.Posts", new[] { "AgeId" });
            DropIndex("dbo.Posts", new[] { "CountryId" });
            DropIndex("dbo.Posts", new[] { "LanguageId" });
            DropIndex("dbo.Posts", new[] { "SexId" });
            AlterColumn("dbo.Posts", "AgeId", c => c.Int());
            AlterColumn("dbo.Posts", "CountryId", c => c.Int());
            AlterColumn("dbo.Posts", "LanguageId", c => c.Int());
            AlterColumn("dbo.Posts", "SexId", c => c.Int());
            CreateIndex("dbo.Posts", "AgeId");
            CreateIndex("dbo.Posts", "CountryId");
            CreateIndex("dbo.Posts", "LanguageId");
            CreateIndex("dbo.Posts", "SexId");
            AddForeignKey("dbo.Posts", "AgeId", "dbo.Ages", "AgeId");
            AddForeignKey("dbo.Posts", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Posts", "LanguageId", "dbo.Languages", "LanguageId");
            AddForeignKey("dbo.Posts", "SexId", "dbo.Sexes", "SexId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "SexId", "dbo.Sexes");
            DropForeignKey("dbo.Posts", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Posts", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Posts", "AgeId", "dbo.Ages");
            DropIndex("dbo.Posts", new[] { "SexId" });
            DropIndex("dbo.Posts", new[] { "LanguageId" });
            DropIndex("dbo.Posts", new[] { "CountryId" });
            DropIndex("dbo.Posts", new[] { "AgeId" });
            AlterColumn("dbo.Posts", "SexId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "LanguageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "AgeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "SexId");
            CreateIndex("dbo.Posts", "LanguageId");
            CreateIndex("dbo.Posts", "CountryId");
            CreateIndex("dbo.Posts", "AgeId");
            AddForeignKey("dbo.Posts", "SexId", "dbo.Sexes", "SexId", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "LanguageId", "dbo.Languages", "LanguageId", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "AgeId", "dbo.Ages", "AgeId", cascadeDelete: true);
        }
    }
}
