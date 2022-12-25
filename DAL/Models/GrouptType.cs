using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GrouptType
    {
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام گروه")]
        [MaxLength(100)]
        public String groupName { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int visit { get; set; }

        [Display(Name = "میزان جریان")]
        public int duration { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "وضعیت")]
        public bool Type { get; set; }=false;

        public List<Song> Songs { get; set; }
        public List<PlayList> PlayLists { get; set; }

    }
}
