using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ViewSong
    {
        public int SongId { get; set; }
        public int GroupId { get; set; }
        public int Score { get; set; }
        public int Visit { get; set; }
        public int CountryId { get; set; }
        public String SongName { get; set; }
        public String SingerName { get; set; }
        public Album Album { get; set; }
        public String Picture { get; set; }
        public String AddressFile { get; set; }
        public bool Remix { get; set; }
        public bool SongType { get; set; }
    }
}
