using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ViewPlayList
    {
        public int PlayListId { get; set; }
        public int Score { get; set; }
        public int Visit { get; set; }
        public bool Type { get; set; }
        public String Picture { get; set; }
        public String Country { get; set; }
        public String PlayListName { get; set; }
    }
}
