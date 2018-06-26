using System.Collections.Generic;

namespace SDV701Server
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Represents a computer manufacturer data entity.
    /// </summary>
    public class ComputerManufacturer
    {
        public int code { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public List<ComputerModel> models { get; set; }
    }
}
