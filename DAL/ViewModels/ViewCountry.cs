﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ViewCountry
    {
        public int CountryId { get; set; }
        public String CountryName { get; set; }
        public List<PlayList> PlayLists { get; set; }
        public List<Singer> Singers { get; set; }
    }
}
