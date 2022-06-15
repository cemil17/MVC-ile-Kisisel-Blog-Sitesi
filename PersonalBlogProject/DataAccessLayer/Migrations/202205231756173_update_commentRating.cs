namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_commentRating : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "BlogRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "BlogRating", c => c.Int(nullable: false));
        }
    }
}
