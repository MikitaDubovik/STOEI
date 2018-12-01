namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Price", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Price");
        }
    }
}
