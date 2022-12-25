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
        [Key]
        public int SingerId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام آوازخوان")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }


        public virtual List<Song> Songs { get; set; }

        public Singer() { }
    }
}
