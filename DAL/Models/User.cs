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
        [Key]
        public int userId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "فامیل")]
        [MaxLength(100)]
        public string Family { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "تلفن")]
        [MaxLength(100)]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "ایمیل")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام کاربری")]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "رمز کاربری")]
        [MaxLength(20)]
        public string Password { get; set; }

        public bool Type { get; set; }
        public double Total { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
