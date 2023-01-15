using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comment
    {
        public int CommentID { get; set; }

        [Display(Name = "نام کامل")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "ایمیل")]
        public string CommentText { get; set; }

        public virtual Album Album { get; set; }
        public virtual Group Group { get; set; }
        public virtual Padcast Padcast { get; set; }
        public virtual PlayList PlayList { get; set; }
        public virtual Song Song { get; set; }
    }
}
