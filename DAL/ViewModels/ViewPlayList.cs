using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ViewPlayList
    {
        public String PlayListName { get; set; }
        public String SongName { get; set; }
        public String AlbumName { get; set; }
        public String SingerName { get; set; }
        public String CountryName { get; set; }
        public String Picture { get; set; }
        public int PlayListId { get; set; }
        public int SongId { get; set; }
        public int Visit { get; set; }
        public int Score { get; set; }
        public bool Type { get; set; }
    }
}
