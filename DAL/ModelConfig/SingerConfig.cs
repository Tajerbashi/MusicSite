using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelConfig
{
    public class SingerConfig:EntityTypeConfiguration<Singer>
    {
        public SingerConfig()
        {
            HasKey(e => e.SingerId);
            Property(e => e.SingerName).HasMaxLength(200).IsRequired();
        }
    }
}
