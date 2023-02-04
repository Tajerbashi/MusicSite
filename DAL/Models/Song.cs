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
        public int SongId { get; set; }

        [Display(Name = "نام آهنگ")]
        public string SongName { get; set; }

        [Display(Name = "گروه")]
        public int GroupId { get; set; }

        //[Required(ErrorMessage = "You Must Fill Input")]
        //[Display(Name = "آوازخوان")]
        //public int SingerId { get; set; }

        [Display(Name = "آلبوم")]
        public int AlbumId { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "عضویت")]
        public bool Type { get; set; }

        [Display(Name = "ریمیکس")]
        public bool Remix { get; set; }

        [Display(Name = "نوع آهنگ")]
        public bool TypeSong { get; set; }

        [Display(Name = "فایل")]
        public string AddressFile { get; set; }

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        [Display(Name = "امتیاز")]
        public int Score { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }


        //public virtual Singer Singer { get; set; }
        public virtual Album Album { get; set; }
        public virtual Group Group { get; set; }
        public virtual List<PlayListSongPKFK> PlayListSongPKFK { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}
