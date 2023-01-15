using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelConfig
{
    public class CountryConfig:EntityTypeConfiguration<Country>
    {
        public CountryConfig()
        {
            HasKey(e => e.CountryId);
            Property(e => e.CountryName).IsRequired();
        }
    }
}
