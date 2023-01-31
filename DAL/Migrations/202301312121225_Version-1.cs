namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Comments", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.Comments", "PlayList_playListId", "dbo.PlayLists");
            DropIndex("dbo.Comments", new[] { "Album_AlbumId" });
            DropIndex("dbo.Comments", new[] { "Group_GroupId" });
            DropIndex("dbo.Comments", new[] { "PlayList_playListId" });
            DropColumn("dbo.Comments", "Album_AlbumId");
            DropColumn("dbo.Comments", "Group_GroupId");
            DropColumn("dbo.Comments", "PlayList_playListId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "PlayList_playListId", c => c.Int());
            AddColumn("dbo.Comments", "Group_GroupId", c => c.Int());
            AddColumn("dbo.Comments", "Album_AlbumId", c => c.Int());
            CreateIndex("dbo.Comments", "PlayList_playListId");
            CreateIndex("dbo.Comments", "Group_GroupId");
            CreateIndex("dbo.Comments", "Album_AlbumId");
            AddForeignKey("dbo.Comments", "PlayList_playListId", "dbo.PlayLists", "playListId");
            AddForeignKey("dbo.Comments", "Group_GroupId", "dbo.Groups", "GroupId");
            AddForeignKey("dbo.Comments", "Album_AlbumId", "dbo.Albums", "AlbumId");
        }
    }
}
