using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlayList
    {
        [Key]
        public int playListId { get; set; }

        [Display(Name = "از کشور")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام پلی لیست")]
        [MaxLength(100)]
        public string PlayListName { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "امتیاز")]
        public int Score { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "عضویت")]
        public bool Type { get; set; }

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        public virtual List<PlayListSongPKFK> PlayListSongPKFK { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<Comment> Comments { get; set; }


    }
}
