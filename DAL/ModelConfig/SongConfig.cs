using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelConfig
{
    public class SongConfig:EntityTypeConfiguration<Song>
    {
        public SongConfig() 
        {
            HasKey(e => e.SongId);
            Property(e => e.SongName).HasMaxLength(200).IsRequired();
            Property(e => e.Type).IsRequired();
            Property(e => e.Remix).IsRequired();

        }
    }
}
