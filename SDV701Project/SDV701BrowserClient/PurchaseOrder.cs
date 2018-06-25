using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701BrowserClient
{
    public class PurchaseOrder
    {
        private int orderNumber;
        private ComputerModel product;
        private DateTime date;
        private string customerName;
        private string customerStreetAddress;
        private string customerCity;
        private string customerPostCode;
        private decimal productPrice;
        private short quantity;

        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public ComputerModel Product { get => product; set => product = value; }
        public DateTime Date { get => date; set => date = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CustomerStreetAddress { get => customerStreetAddress; set => customerStreetAddress = value; }
        public string CustomerCity { get => customerCity; set => customerCity = value; }
        public string CustomerPostCode { get => customerPostCode; set => customerPostCode = value; }
        public decimal ProductPrice { get => productPrice; set => productPrice = value; }
        public short Quantity { get => quantity; set => quantity = value; }

        public override string ToString()
        {
            return $"{orderNumber.ToString("D10")}\t{date.ToLocalTime().ToString()}\t{customerName}\t\t{product.Name}\t{quantity}\t{productPrice.ToString("C2")}\t\t{(productPrice * quantity).ToString("C2")}";
        }
    }
}
