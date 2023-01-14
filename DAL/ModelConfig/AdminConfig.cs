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
            Property(e => e.Name).HasMaxLength(200).IsRequired();
        }
    }
}
