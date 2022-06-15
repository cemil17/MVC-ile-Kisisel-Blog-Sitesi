namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blog_added_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogStatus");
        }
    }
}
