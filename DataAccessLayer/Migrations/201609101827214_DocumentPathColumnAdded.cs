namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentPathColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentLinks", "DocumentPath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentLinks", "DocumentPath");
        }
    }
}
