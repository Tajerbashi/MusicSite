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
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        SingerId = c.Int(nullable: false),
                        AlbumName = c.String(nullable: false, maxLength: 100),
                        Visit = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Type = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Singers", t => t.SingerId, cascadeDelete: true)
                .Index(t => t.SingerId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        CommentText = c.String(nullable: false),
                        Album_AlbumId = c.Int(),
                        Group_GroupId = c.Int(),
                        Song_SongId = c.Int(),
                        PlayList_playListId = c.Int(),
                        Padcast_PadcastId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .ForeignKey("dbo.Songs", t => t.Song_SongId)
                .ForeignKey("dbo.PlayLists", t => t.PlayList_playListId)
                .ForeignKey("dbo.Padcasts", t => t.Padcast_PadcastId)
                .Index(t => t.Album_AlbumId)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Song_SongId)
                .Index(t => t.PlayList_playListId)
                .Index(t => t.Padcast_PadcastId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 100),
                        Visit = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        SongName = c.String(nullable: false, maxLength: 200),
                        GroupId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Remix = c.Boolean(nullable: false),
                        AddressFile = c.String(),
                        Picture = c.String(),
                        Score = c.Int(nullable: false),
                        Visit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.PlayListSongPKFKs",
                c => new
                    {
                        IDPlayListSongPKFK = c.Int(nullable: false, identity: true),
                        PlayList_playListId = c.Int(),
                        Song_SongId = c.Int(),
                    })
                .PrimaryKey(t => t.IDPlayListSongPKFK)
                .ForeignKey("dbo.PlayLists", t => t.PlayList_playListId)
                .ForeignKey("dbo.Songs", t => t.Song_SongId)
                .Index(t => t.PlayList_playListId)
                .Index(t => t.Song_SongId);
            
            CreateTable(
                "dbo.PlayLists",
                c => new
                    {
                        playListId = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        PlayListName = c.String(nullable: false, maxLength: 100),
                        Visit = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.playListId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Padcasts",
                c => new
                    {
                        PadcastId = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        PadcastName = c.String(nullable: false, maxLength: 100),
                        Score = c.Int(nullable: false),
                        Visit = c.Int(nullable: false),
                        Type = c.Boolean(nullable: false),
                        AddressFile = c.String(),
                        Picture = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PadcastId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        SingerId = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        SingerName = c.String(nullable: false, maxLength: 200),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SingerId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Family = c.String(nullable: false, maxLength: 200),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Photo = c.String(),
                        Type = c.Boolean(nullable: false),
                        Total = c.Double(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayListSongPKFKs", "Song_SongId", "dbo.Songs");
            DropForeignKey("dbo.PlayListSongPKFKs", "PlayList_playListId", "dbo.PlayLists");
            DropForeignKey("dbo.Singers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Albums", "SingerId", "dbo.Singers");
            DropForeignKey("dbo.PlayLists", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Padcasts", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Comments", "Padcast_PadcastId", "dbo.Padcasts");
            DropForeignKey("dbo.Comments", "PlayList_playListId", "dbo.PlayLists");
            DropForeignKey("dbo.Songs", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Comments", "Song_SongId", "dbo.Songs");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Comments", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.Comments", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.Singers", new[] { "CountryId" });
            DropIndex("dbo.Padcasts", new[] { "CountryId" });
            DropIndex("dbo.PlayLists", new[] { "CountryId" });
            DropIndex("dbo.PlayListSongPKFKs", new[] { "Song_SongId" });
            DropIndex("dbo.PlayListSongPKFKs", new[] { "PlayList_playListId" });
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.Songs", new[] { "GroupId" });
            DropIndex("dbo.Comments", new[] { "Padcast_PadcastId" });
            DropIndex("dbo.Comments", new[] { "PlayList_playListId" });
            DropIndex("dbo.Comments", new[] { "Song_SongId" });
            DropIndex("dbo.Comments", new[] { "Group_GroupId" });
            DropIndex("dbo.Comments", new[] { "Album_AlbumId" });
            DropIndex("dbo.Albums", new[] { "SingerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Singers");
            DropTable("dbo.Padcasts");
            DropTable("dbo.Countries");
            DropTable("dbo.PlayLists");
            DropTable("dbo.PlayListSongPKFKs");
            DropTable("dbo.Songs");
            DropTable("dbo.Groups");
            DropTable("dbo.Comments");
            DropTable("dbo.Albums");
            DropTable("dbo.Admins");
        }
    }
}
