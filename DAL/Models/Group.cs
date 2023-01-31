using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Group
    {
        public int GroupId { get; set; }

        [Display(Name = "نام گروه")]
        public String GroupName { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }

        [Display(Name = "امتیاز")]
        public int Score { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
        public virtual List<Song> Songs { get; set; }

    }
}
