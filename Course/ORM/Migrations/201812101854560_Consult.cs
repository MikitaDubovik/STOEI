namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Consult : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Users", "RegionId", "dbo.Regions");
            DropIndex("dbo.Posts", new[] { "RegionId" });
            DropIndex("dbo.Users", new[] { "RegionId" });
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            AddColumn("dbo.Posts", "CountryId", c => c.Int());
            AddColumn("dbo.Users", "CountryId", c => c.Int());
            CreateIndex("dbo.Posts", "CountryId");
            CreateIndex("dbo.Users", "CountryId");
            AddForeignKey("dbo.Posts", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Users", "CountryId", "dbo.Countries", "CountryId");
            DropColumn("dbo.Posts", "RegionId");
            DropColumn("dbo.Users", "RegionId");
            DropTable("dbo.Regions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.RegionId);
            
            AddColumn("dbo.Users", "RegionId", c => c.Int());
            AddColumn("dbo.Posts", "RegionId", c => c.Int());
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Posts", "CountryId", "dbo.Countries");
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropIndex("dbo.Posts", new[] { "CountryId" });
            DropColumn("dbo.Users", "CountryId");
            DropColumn("dbo.Posts", "CountryId");
            DropTable("dbo.Countries");
            CreateIndex("dbo.Users", "RegionId");
            CreateIndex("dbo.Posts", "RegionId");
            AddForeignKey("dbo.Users", "RegionId", "dbo.Regions", "RegionId");
            AddForeignKey("dbo.Posts", "RegionId", "dbo.Regions", "RegionId");
        }
    }
}
