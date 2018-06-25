using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701BrowserClient
{
    public class ComputerModel
    {
        private short quantity;

        public readonly string Name;
        public readonly string Manufacturer;
        public readonly string type;
        public readonly decimal Price;
        public readonly DateTime ModifiedDate;
        public readonly string OperatingSystem;
        public readonly string ProcessorFamily;
        public readonly string GraphicsFamily;
        public readonly int Storage;
        public readonly byte Memory;
        public readonly short PowerSupply;
        public readonly string TowerForm;
        public readonly byte ScreenSize;
        public readonly byte BatteryLife;
        public readonly bool Webcamera;
        public readonly bool FullsizeKeyboard;

        public short Quantity { get => quantity; set => quantity = value; }

        private ComputerModel() { }

        public override string ToString()
        {
            return $"{Name}\t\t{(Name.Length > 8 ? "" : "\t")}{Price:C2}\t{(Price.ToString("C2").Length > 8 ? "" : "\t")}{Quantity}";
        }


    }
}
