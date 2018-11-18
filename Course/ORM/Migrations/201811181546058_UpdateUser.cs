namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AgeId", c => c.Int());
            AddColumn("dbo.Users", "CountryId", c => c.Int());
            AddColumn("dbo.Users", "LanguageId", c => c.Int());
            AddColumn("dbo.Users", "SexId", c => c.Int());
            CreateIndex("dbo.Users", "AgeId");
            CreateIndex("dbo.Users", "CountryId");
            CreateIndex("dbo.Users", "LanguageId");
            CreateIndex("dbo.Users", "SexId");
            AddForeignKey("dbo.Users", "AgeId", "dbo.Ages", "AgeId");
            AddForeignKey("dbo.Users", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Users", "LanguageId", "dbo.Languages", "LanguageId");
            AddForeignKey("dbo.Users", "SexId", "dbo.Sexes", "SexId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SexId", "dbo.Sexes");
            DropForeignKey("dbo.Users", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Users", "AgeId", "dbo.Ages");
            DropIndex("dbo.Users", new[] { "SexId" });
            DropIndex("dbo.Users", new[] { "LanguageId" });
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropIndex("dbo.Users", new[] { "AgeId" });
            DropColumn("dbo.Users", "SexId");
            DropColumn("dbo.Users", "LanguageId");
            DropColumn("dbo.Users", "CountryId");
            DropColumn("dbo.Users", "AgeId");
        }
    }
}
