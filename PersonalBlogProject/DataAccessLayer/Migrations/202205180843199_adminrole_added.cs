namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminrole_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Role", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Role");
        }
    }
}
