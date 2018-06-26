using System;
using System.Collections.Generic;

namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Represents a computer model loaded from the database, or newly created, for the purpose of editing.
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

        public delegate void loadEditFormDelegate(ComputerModel computerModel, bool editing);

        public static Dictionary<string, loadEditFormDelegate> loadForm = new Dictionary<string, loadEditFormDelegate>();

        public ComputerModel() { }

        public ComputerModel(string type, string manufacturer)
        {
            this.type = type;
            this.manufacturer = manufacturer;
            this.modifiedDate = DateTime.Now;
        }

        public void editDetails()
        {
            loadForm[type](this, true);
        }

        public void showDetails()
        {
            loadForm[type](this, false);
        }

        public override string ToString()
        {
            return $"{name}\t{(name.Length > 8 ? "" : "\t")}{price:C2}\t{(price.ToString("C2").Length > 8 ? "" : "\t")}{quantity}";
        }


    }
}
