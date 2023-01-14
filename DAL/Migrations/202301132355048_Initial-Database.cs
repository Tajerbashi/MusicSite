namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "SingerId", "dbo.Singers");
            DropForeignKey("dbo.Songs", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "SingerId" });
            DropIndex("dbo.Songs", new[] { "Album_AlbumId" });
            RenameColumn(table: "dbo.Songs", name: "Album_AlbumId", newName: "AlbumId");
            AlterColumn("dbo.Songs", "AlbumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Songs", "AlbumId");
            AddForeignKey("dbo.Songs", "AlbumId", "dbo.Albums", "AlbumId", cascadeDelete: true);
            DropColumn("dbo.Songs", "SingerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "SingerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            AlterColumn("dbo.Songs", "AlbumId", c => c.Int());
            RenameColumn(table: "dbo.Songs", name: "AlbumId", newName: "Album_AlbumId");
            CreateIndex("dbo.Songs", "Album_AlbumId");
            CreateIndex("dbo.Songs", "SingerId");
            AddForeignKey("dbo.Songs", "Album_AlbumId", "dbo.Albums", "AlbumId");
            AddForeignKey("dbo.Songs", "SingerId", "dbo.Singers", "SingerId", cascadeDelete: true);
        }
    }
}
