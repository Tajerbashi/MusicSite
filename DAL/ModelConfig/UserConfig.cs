using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelConfig
{
    public class UserConfig:EntityTypeConfiguration<User>
    {
        public UserConfig() 
        {
            HasKey(e => e.userId);
            Property(e => e.Name).HasMaxLength(200).IsRequired();
            Property(e => e.Family).HasMaxLength(200).IsRequired();
            Property(e => e.Phone).HasMaxLength(11).IsRequired();
            Property(e => e.Email).HasMaxLength(50).IsRequired();
            Property(e => e.Username).HasMaxLength(20).IsRequired();
            Property(e => e.Password).HasMaxLength(20).IsRequired();
            Property(e => e.Type).IsRequired();
        }

    }
}
