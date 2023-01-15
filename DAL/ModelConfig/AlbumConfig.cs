using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelConfig
{
    public class AlbumConfig : EntityTypeConfiguration<Album>
    {
        public AlbumConfig()
        {
            HasKey(e => e.AlbumId);
            Property(e => e.AlbumName).HasMaxLength(100).IsRequired();
        }
    }
}
