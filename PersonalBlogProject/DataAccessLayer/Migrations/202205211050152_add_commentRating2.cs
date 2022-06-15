namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_commentRating2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "BlogRating", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "BlogRating");
        }
    }
}
