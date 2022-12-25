using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Admin
    {
        [Key]
        public int adminId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "فامیل")]
        [MaxLength(100)]
        public string Family { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "ایمیل")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "تلفن")]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام کاربری")]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "رمز کاربری")]
        [MaxLength(20)]
        public string Password { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }
        
    }

}
