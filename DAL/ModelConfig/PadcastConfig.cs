using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelConfig
{
    public class PadcastConfig:EntityTypeConfiguration<Padcast>
    {
        public PadcastConfig()
        {
            HasKey(e => e.PadcastId);
            Property(e => e.PadcastName).HasMaxLength(100).IsRequired();
        }
    }
}
