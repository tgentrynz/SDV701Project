using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701AdminClient
{
    public class ComputerManufacturer
    {
        private int code;
        private string name;
        private string country;
        private List<ComputerModel> models;

        public int Code {get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Country { get => country; set => country = value; }
        public List<ComputerModel> Models { get => models; set => models = value; }
    }
}
