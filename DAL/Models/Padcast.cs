using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Padcast
    {
        public int PadcastId { get; set; }

        [Display(Name = "نام کشور")]
        public int CountryId { get; set; }

        [Display(Name = "نام پاد کست")]
        public string PadcastName { get; set; }

        [Display(Name = "امتیاز")]
        public int Score { get; set; } = 0;

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; } = 0;

        [Display(Name = "عضویت")]
        public bool Type { get; set; }

        [Display(Name = "فایل")]
        public string AddressFile { get; set; }

        [Display(Name = "تصویر")]
        public string Picture { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual List<Comment> Comments { get; set; }
        public virtual Country Country { get; set; }
        
    }
}
