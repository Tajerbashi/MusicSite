using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Song
    {
        [Key]
        public int songId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام آهنگ")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "وضعیت")]
        public bool Type { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "فایل")]
        public string AddressFile { get; set; }

        public Singer Singer { get; set; }
        public GrouptType GrouptType { get; set; }
        public List<PlayList> PlayLists { get; set; }


    }
}
