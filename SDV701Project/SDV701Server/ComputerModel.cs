using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701Server
{
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

        public Dictionary<string, Object> toParameterList()
        {
            return new Dictionary<string, object>()
            {
                { "modelName", name },
                { "manufacturer", InventoryController.getManufacturerCode(manufacturer)},
                { "modelType", type},
                { "price", price},
                { "quantity", quantity},
                { "operatingSystem", operatingSystem},
                { "processorFamily", processorFamily},
                { "graphicsFamily", graphicsFamily},
                { "storage", storage},
                { "memory", memory},
                { "powerSupply", powerSupply},
                { "towerForm", towerForm},
                { "screenSize", screenSize},
                { "batteryLife", batteryLife},
                { "webCamera", webcamera},
                { "fullsizeKeyboard", fullsizeKeyboard}
            };
        }
    }


}
