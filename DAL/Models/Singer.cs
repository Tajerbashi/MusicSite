using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Singer
    {
        public int SingerId { get; set; }

        [Display(Name = "نام کشور")]
        public int CountryId { get; set; }

        [Display(Name = "نام آوازخوان")]
        public string SingerName { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;


        //public virtual List<Song> Songs { get; set; }
        public virtual List<Album> Albums { get; set; }
        public virtual Country Country { get; set; }

        public Singer() { }
    }
}
