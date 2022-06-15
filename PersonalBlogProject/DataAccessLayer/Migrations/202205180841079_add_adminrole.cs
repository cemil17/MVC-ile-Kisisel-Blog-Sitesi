namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_adminrole : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "UserName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "UserName", c => c.String());
        }
    }
}
