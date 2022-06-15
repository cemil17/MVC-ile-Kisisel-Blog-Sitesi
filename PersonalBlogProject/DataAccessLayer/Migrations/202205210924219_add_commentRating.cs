namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_commentRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Rating");
        }
    }
}
