using System;

namespace SDV701BrowserClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Represents a computer model loaded from the data base.
    /// </summary>
    public class ComputerModel
    {

        public string name { get; set; }
        public string manufacturer { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public short quantity { get; set; }
        public DateTime modifiedDate { get; set; }
        public string operatingSystem { get; set; }
        public string processorFamily { get; set; }
        public string graphicsFamily { get; set; }
        public int storage { get; set; }
        public byte memory { get; set; }
        public short powerSupply { get; set; }
        public string towerForm { get; set; }
        public byte screenSize { get; set; }
        public byte batteryLife { get; set; }
        public bool webcamera { get; set; }
        public bool fullsizeKeyboard { get; set; }

        private ComputerModel() { }

        public override string ToString()
        {
            return $"{name}\t\t{(name.Length > 8 ? "" : "\t")}{price:C2}\t{(price.ToString("C2").Length > 8 ? "" : "\t")}{quantity}";
        }


    }
}
