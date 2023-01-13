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

        public System.Data.Entity.DbSet<DAL.PlayListSongPKFK> PlayListSongPKFKs { get; set; }
    }
}
