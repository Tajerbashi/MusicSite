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

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual Song Song { get; set; }
    }
}
