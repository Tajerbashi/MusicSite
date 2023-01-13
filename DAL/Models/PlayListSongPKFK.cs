using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlayListSongPKFK
    {
        [Key]
        public int IDPlayListSongPKFK { get; set; }

        public virtual Song Song { get; set; }
        public virtual PlayList PlayList { get; set; }
    }
}
