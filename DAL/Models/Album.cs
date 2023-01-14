using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Display(Name = "نام خواننده")]
        public int SingerId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام آلبوم")]
        [MaxLength(100)]
        public string AlbumName { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }

        [Display(Name = "امتیاز")]
        public int Score { get; set; }

        [Display(Name = "عضویت")]
        public bool Type { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;


        public virtual List<Song> Songs { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual Singer Singer { get; set; }

    }
}
