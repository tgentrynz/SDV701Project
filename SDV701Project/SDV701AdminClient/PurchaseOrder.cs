using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701AdminClient
{
    public class PurchaseOrder
    {
        public readonly int OrderNumber;
        public readonly ComputerModel Product;
        public readonly DateTime Date;
        public readonly string CustomerName;
        public readonly string CustomerStreetAddress;
        public readonly string CustomerCity;
        public readonly string CustomerPostCode;
        public readonly decimal ProductPrice;
        public readonly short Quantity;

        public override string ToString()
        {
            return $"{OrderNumber.ToString("D10")}\t{Date.ToLocalTime().ToShortDateString()}\t{CustomerName}\t\t{(Product != null ? Product.Name : "ITEM REMOVED")}\t{Quantity}\t{ProductPrice.ToString("C2")}\t\t{(ProductPrice * Quantity).ToString("C2")}";
        }
    }
}
