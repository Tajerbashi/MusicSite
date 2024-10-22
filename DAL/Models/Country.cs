﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Country
    {
        public int CountryId { get; set; }

        [Display(Name = "نام کشور")]
        public string CountryName { get; set; }

        public List<PlayList> PlayLists { get; set; }
        public List<Singer> Singers { get; set; }
    }
}
