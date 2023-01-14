using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "You Must Fill Input")]
        [Display(Name = "نام کشور")]
        public string CountryName { get; set; }

        public List<Padcast> Padcasts { get; set; }
        public List<PlayList> PlayLists { get; set; }
        public List<Singer> Singers { get; set; }
    }
}
