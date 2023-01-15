using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DAL.ModelConfig
{
    public class CommentConfig:EntityTypeConfiguration<Comment>
    {
        public CommentConfig() {
            HasKey(e => e.CommentID);
            Property(e => e.FullName).IsRequired().HasMaxLength(100);
            Property(e => e.Email).IsRequired().HasMaxLength(100);
            Property(e => e.CommentText).IsRequired();
        }
    }
}
