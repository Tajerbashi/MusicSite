using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PlayListSongPKFK
    {
        [Key]
        public int IDPlayListSongPKFK { get; set; }

        public Song Song { get; set; }
        public PlayList PlayList { get; set; }
    }
}
