namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_comment_ratingforblog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "RatingForBlog", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "RatingForBlog");
        }
    }
}
