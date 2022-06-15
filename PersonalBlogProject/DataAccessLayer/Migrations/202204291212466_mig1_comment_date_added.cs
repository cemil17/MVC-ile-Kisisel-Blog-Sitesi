namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1_comment_date_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentDate");
        }
    }
}
