using System.Collections.Generic;

namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Represents a computer manufacturer loaded from the database.
    /// </summary>
    public class ComputerManufacturer
    {
        public int code { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public List<ComputerModel> models { get; set; }
    }
}
