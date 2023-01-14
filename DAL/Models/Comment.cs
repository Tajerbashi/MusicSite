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
        [Key]
        public int CommentID { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام کامل")]
        [MaxLength(100)]
        public string FullName { get; set; }


        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "ایمیل")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "ایمیل")]
        public string CommentText { get; set; }

        public virtual Album Album { get; set; }
        public virtual Group Group { get; set; }
        public virtual Padcast Padcast { get; set; }
        public virtual PlayList PlayList { get; set; }
        public virtual Song Song { get; set; }
    }
}
