using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ViewPadcast
    {
        public int PadcastId { get; set; }
        public string PadcastName { get; set; }
        public string AddressFile { get; set; }
        public string Picture { get; set; }
        public int Score { get; set; }
        public int Visit { get; set; }
        public bool Type { get; set; }
    }
}
