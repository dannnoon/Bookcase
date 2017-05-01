namespace Bookcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCoverUri : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "CoverUri");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "CoverUri", c => c.String());
        }
    }
}
