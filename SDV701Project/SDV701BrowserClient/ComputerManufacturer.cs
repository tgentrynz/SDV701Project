using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701BrowserClient
{
    public class ComputerManufacturer
    {
        public readonly int Code;
        public readonly string Name;
        public readonly string Country;
        public readonly List<ComputerModel> Models;
    }
}
