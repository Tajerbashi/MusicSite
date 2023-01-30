using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ViewSinger
    {
        public int SingerId { get; set; }
        public int CountryId { get; set; }
        public int SongCount { get; set; }
        public string SingerName { get; set; }
        public string Picture { get; set; }
    }
}
