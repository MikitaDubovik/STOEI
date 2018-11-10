namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ages",
                c => new
                    {
                        AgeId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.AgeId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Posted = c.DateTime(nullable: false),
                        Text = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        NumberOfLikes = c.Int(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Image = c.Binary(nullable: false),
                        IsAd = c.Boolean(nullable: false),
                        AgeId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        SexId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Ages", t => t.AgeId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Sexes", t => t.SexId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AgeId)
                .Index(t => t.CountryId)
                .Index(t => t.LanguageId)
                .Index(t => t.SexId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        SexId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.SexId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        Login = c.String(nullable: false),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(),
                        ProfilePhoto = c.Binary(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserLikesEntities",
                c => new
                    {
                        UserLikesEntityId = c.Int(nullable: false, identity: true),
                        UserLikesId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserLikesEntityId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.UserLikesEntities", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Tags", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "SexId", "dbo.Sexes");
            DropForeignKey("dbo.Posts", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Posts", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Posts", "AgeId", "dbo.Ages");
            DropIndex("dbo.UserLikesEntities", new[] { "PostId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Tags", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "SexId" });
            DropIndex("dbo.Posts", new[] { "LanguageId" });
            DropIndex("dbo.Posts", new[] { "CountryId" });
            DropIndex("dbo.Posts", new[] { "AgeId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.UserLikesEntities");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Sexes");
            DropTable("dbo.Languages");
            DropTable("dbo.Countries");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Ages");
        }
    }
}
