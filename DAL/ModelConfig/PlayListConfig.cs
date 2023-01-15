using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelConfig
{
    public class PlayListConfig:EntityTypeConfiguration<PlayList>
    {
        public PlayListConfig() 
        {
            HasKey(e => e.playListId);
            Property(e => e.PlayListName).HasMaxLength(100).IsRequired();
            Property(e => e.Type).IsRequired();
        }
    }
}
