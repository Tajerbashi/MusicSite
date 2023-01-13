using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Padcast
    {
        [Key]
        public int PadcastId { get; set; }
        public int CountryId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام پاد کست")]
        [MaxLength(100)]
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
