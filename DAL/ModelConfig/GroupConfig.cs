using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelConfig
{
    public class GroupConfig:EntityTypeConfiguration<Group>
    {
        public GroupConfig()
        {
            HasKey(e => e.GroupId);
            Property(e => e.GroupName).HasMaxLength(100).IsRequired();
        }
    }
}
