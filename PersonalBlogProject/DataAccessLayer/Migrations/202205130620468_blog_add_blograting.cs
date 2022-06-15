namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blog_add_blograting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogRating");
        }
    }
}
