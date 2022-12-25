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
                        groupName = c.String(nullable: false, maxLength: 100),
                        visit = c.Int(nullable: false),
                        duration = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.PlayLists",
                c => new
                    {
                        playListId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        PlayCount = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        GrouptType_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.playListId)
                .ForeignKey("dbo.GrouptTypes", t => t.GrouptType_GroupId)
                .Index(t => t.GrouptType_GroupId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        songId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        Type = c.Boolean(nullable: false),
                        AddressFile = c.String(nullable: false),
                        GrouptType_GroupId = c.Int(),
                        Singer_SingerId = c.Int(),
                    })
                .PrimaryKey(t => t.songId)
                .ForeignKey("dbo.GrouptTypes", t => t.GrouptType_GroupId)
                .ForeignKey("dbo.Singers", t => t.Singer_SingerId)
                .Index(t => t.GrouptType_GroupId)
                .Index(t => t.Singer_SingerId);
            
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        SingerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
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
            
            CreateTable(
                "dbo.SongPlayLists",
                c => new
                    {
                        Song_songId = c.Int(nullable: false),
                        PlayList_playListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_songId, t.PlayList_playListId })
                .ForeignKey("dbo.Songs", t => t.Song_songId, cascadeDelete: true)
                .ForeignKey("dbo.PlayLists", t => t.PlayList_playListId, cascadeDelete: true)
                .Index(t => t.Song_songId)
                .Index(t => t.PlayList_playListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Singer_SingerId", "dbo.Singers");
            DropForeignKey("dbo.SongPlayLists", "PlayList_playListId", "dbo.PlayLists");
            DropForeignKey("dbo.SongPlayLists", "Song_songId", "dbo.Songs");
            DropForeignKey("dbo.Songs", "GrouptType_GroupId", "dbo.GrouptTypes");
            DropForeignKey("dbo.PlayLists", "GrouptType_GroupId", "dbo.GrouptTypes");
            DropIndex("dbo.SongPlayLists", new[] { "PlayList_playListId" });
            DropIndex("dbo.SongPlayLists", new[] { "Song_songId" });
            DropIndex("dbo.Songs", new[] { "Singer_SingerId" });
            DropIndex("dbo.Songs", new[] { "GrouptType_GroupId" });
            DropIndex("dbo.PlayLists", new[] { "GrouptType_GroupId" });
            DropTable("dbo.SongPlayLists");
            DropTable("dbo.Users");
            DropTable("dbo.Singers");
            DropTable("dbo.Songs");
            DropTable("dbo.PlayLists");
            DropTable("dbo.GrouptTypes");
            DropTable("dbo.Admins");
        }
    }
}
