namespace Bookcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublicationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PublicationDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "PublicationDate");
        }
    }
}
