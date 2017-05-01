namespace Bookcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCover : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Cover", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Cover");
        }
    }
}
