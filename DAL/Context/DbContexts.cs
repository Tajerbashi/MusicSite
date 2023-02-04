using DAL.ModelConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DbContexts:DbContext
    {
        public DbContexts():base("name=DB") { }

        public DbSet<Song> Songs { get; set; } 
        public DbSet<Admin> Admins { get; set; } 
        public DbSet<Group> GrouptTypes { get; set; } 
        public DbSet<PlayList> PlayLists { get; set; } 
        public DbSet<Singer> Singers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }


        public System.Data.Entity.DbSet<DAL.PlayListSongPKFK> PlayListSongPKFKs { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminConfig());
            modelBuilder.Configurations.Add(new AlbumConfig());
            modelBuilder.Configurations.Add(new CommentConfig());
            modelBuilder.Configurations.Add(new CountryConfig());
            modelBuilder.Configurations.Add(new GroupConfig());
            modelBuilder.Configurations.Add(new PlayListConfig());
            modelBuilder.Configurations.Add(new SongConfig());
            modelBuilder.Configurations.Add(new SingerConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
