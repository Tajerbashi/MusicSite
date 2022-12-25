using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlayList
    {
        [Key]
        public int playListId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام لیست")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تعداد پخش")]
        public int PlayCount { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }

        public List<Song> Songs { get; set; }
        public GrouptType GrouptType { get; set; }


    }
}
