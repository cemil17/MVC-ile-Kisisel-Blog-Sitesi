﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_authorstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorStatus");
        }
    }
}
