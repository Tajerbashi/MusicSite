using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace DAL
{
    public class AdminConfig:EntityTypeConfiguration<Admin>
    {
        public AdminConfig()
        {
            HasKey(e => e.adminId);
            Property(e => e.Name).HasMaxLength(100).IsRequired();
            Property(e => e.Family).HasMaxLength(100).IsRequired();
            Property(e => e.Email).HasMaxLength(150).IsRequired();
            Property(e => e.Phone).HasMaxLength(11).IsRequired();
            Property(e => e.Username).HasMaxLength(20).IsRequired();
            Property(e => e.Password).HasMaxLength(20).IsRequired();
        }
    }
}
