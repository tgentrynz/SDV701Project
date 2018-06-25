using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701Server
{
    public class ComputerManufacturer
    {
        public int code { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public List<ComputerModel> models { get; set; }
    }
}
