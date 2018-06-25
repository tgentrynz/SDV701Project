using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701AdminClient
{
    public class ComputerModel
    {
        private string name;
        private string manufacturer;
        private string type;
        private decimal price;
        private short quantity;
        private DateTime modifiedDate;
        private string operatingSystem;
        private string processorFamily;
        private string graphicsFamily;
        private int storage;
        private byte memory;
        private short powerSupply;
        private string towerForm;
        private byte screenSize;
        private byte batteryLife;
        private bool webcamera;
        private bool fullsizeKeyboard;

        public string Name { get => name; set => name = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Type { get => type; set => type = value; }
        public decimal Price { get => price; set => price = value; }
        public short Quantity { get => quantity; set => quantity = value; }
        public DateTime ModifiedDate { get => modifiedDate; set => modifiedDate = value; }
        public string OperatingSystem { get => operatingSystem; set => operatingSystem = value; }
        public string ProcessorFamily { get => processorFamily; set => processorFamily = value; }
        public string GraphicsFamily { get => graphicsFamily; set => graphicsFamily = value; }
        public int Storage { get => storage; set => storage = value; }
        public byte Memory { get => memory; set => memory = value; }
        public short PowerSupply { get => powerSupply; set => powerSupply = value; }
        public string TowerForm { get => towerForm; set => towerForm = value; }
        public byte ScreenSize { get => screenSize; set => screenSize = value; }
        public byte BatteryLife { get => batteryLife; set => batteryLife = value; }
        public bool Webcamera { get => webcamera; set => webcamera = value; }
        public bool FullsizeKeyboard { get => fullsizeKeyboard; set => fullsizeKeyboard = value; }

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
