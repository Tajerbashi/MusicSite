using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class User
    {
        public int userId { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "فامیل")]
        public string Family { get; set; }

        [Display(Name = "تلفن")]
        public string Phone { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Display(Name = "رمز کاربری")]
        public string Password { get; set; }

        [Display(Name = "تصویر")]
        public string Photo { get; set; }

        [Display(Name = "عضویت")]
        public bool Type { get; set; }

        [Display(Name = "مجموعه خرید")]
        public double Total { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
