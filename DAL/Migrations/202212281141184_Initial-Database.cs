namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        adminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Family = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.adminId);
            
            CreateTable(
                "dbo.GrouptTypes",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        visit = c.Int(nullable: false),
                        duration = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        songId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        GroupId = c.Int(nullable: false),
                        SingerId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        Type = c.Boolean(nullable: false),
                        AddressFile = c.String(),
                        Picture = c.String(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.songId)
                .ForeignKey("dbo.GrouptTypes", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Singers", t => t.SingerId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SingerId);
            
            CreateTable(
                "dbo.PlayListSongPKFKs",
                c => new
                    {
                        IDPlayListSongPKFK = c.Int(nullable: false, identity: true),
                        PlayList_playListId = c.Int(),
                        Song_songId = c.Int(),
                    })
                .PrimaryKey(t => t.IDPlayListSongPKFK)
                .ForeignKey("dbo.PlayLists", t => t.PlayList_playListId)
                .ForeignKey("dbo.Songs", t => t.Song_songId)
                .Index(t => t.PlayList_playListId)
                .Index(t => t.Song_songId);
            
            CreateTable(
                "dbo.PlayLists",
                c => new
                    {
                        playListId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        PlayCount = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.playListId);
            
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        SingerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SingerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Family = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Type = c.Boolean(nullable: false),
                        Total = c.Double(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "SingerId", "dbo.Singers");
            DropForeignKey("dbo.PlayListSongPKFKs", "Song_songId", "dbo.Songs");
            DropForeignKey("dbo.PlayListSongPKFKs", "PlayList_playListId", "dbo.PlayLists");
            DropForeignKey("dbo.Songs", "GroupId", "dbo.GrouptTypes");
            DropIndex("dbo.PlayListSongPKFKs", new[] { "Song_songId" });
            DropIndex("dbo.PlayListSongPKFKs", new[] { "PlayList_playListId" });
            DropIndex("dbo.Songs", new[] { "SingerId" });
            DropIndex("dbo.Songs", new[] { "GroupId" });
            DropTable("dbo.Users");
            DropTable("dbo.Singers");
            DropTable("dbo.PlayLists");
            DropTable("dbo.PlayListSongPKFKs");
            DropTable("dbo.Songs");
            DropTable("dbo.GrouptTypes");
            DropTable("dbo.Admins");
        }
    }
}
