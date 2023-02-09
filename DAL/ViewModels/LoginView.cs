using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginView
    {
        [Display(Name ="نام کاربری")]
        public String Username { get; set; }
        [Display(Name = "رمز کاربری")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Display(Name = "مرا بخاطر بسپار !")]
        public bool Remember { get; set; }
    }
}
