namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "AddressFile", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "AddressFile", c => c.String(nullable: false));
        }
    }
}
