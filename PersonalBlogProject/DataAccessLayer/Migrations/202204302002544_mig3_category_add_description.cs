namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3_category_add_description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryDescription");
        }
    }
}
