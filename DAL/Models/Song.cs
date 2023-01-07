using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Song
    {
        public Song()
        {
        }
        [Key]
        public int songId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام آهنگ")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "گروه")]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "آوازخوان")]
        public int SingerId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "عضویت")]
        public bool Type { get; set; }

        [Display(Name = "فایل")]
        public string AddressFile { get; set; }

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        [Display(Name = "امتیاز")]
        public int Score { get; set; }

        
        public virtual Singer Singer { get; set; }
        public virtual GrouptType GrouptType { get; set; }
        public virtual List<PlayListSongPKFK> PlayListSongPKFK { get; set; }



    }
}
