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
        public int playListId { get; set; }

        [Display(Name = "از کشور")]
        public int CountryId { get; set; }

        [Display(Name = "نام پلی لیست")]
        public string PlayListName { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "امتیاز")]
        public int Score { get; set; }

        [Display(Name = "عضویت")]
        public bool Type { get; set; }

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        public virtual List<PlayListSongPKFK> PlayListSongPKFK { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<Comment> Comments { get; set; }


    }
}
