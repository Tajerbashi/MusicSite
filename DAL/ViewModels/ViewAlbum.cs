using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ViewAlbum
    {
        public int AlbumId { get; set; }
        public String AlbumName { get; set; }
        public String SingerName { get; set; }
        public String Picture { get; set; }
        public int Score { get; set; }
        public int Visit { get; set; }
    }
}
