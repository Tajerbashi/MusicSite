using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ViewModelSongs
    {
        public int SongId { get; set; }
        public String SongName { get; set; }
        public String SingerName { get; set; }
        public String AlbumName { get; set; }
        public String Picture { get; set; }
        public String AddressFile { get; set; }
        public bool Remix { get; set; }
    }
}
