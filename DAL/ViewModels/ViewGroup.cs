using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ViewGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int Visit { get; set; }
        public int Score { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
