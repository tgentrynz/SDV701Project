using System;

namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Represents a purchase order loaded from the data base.
    /// </summary>
    public class PurchaseOrder
    {
        public int orderNumber { get; set; }
        public ComputerModel product { get; set; }
        public DateTime date { get; set; }
        public string customerName { get; set; }
        public string customerStreetAddress { get; set; }
        public string customerCity { get; set; }
        public string customerPostCode { get; set; }
        public decimal productPrice { get; set; }
        public short quantity { get; set; }

        public override string ToString()
        {
            return $"{orderNumber.ToString("D10")}\t{date.ToLocalTime().ToShortDateString()}\t{customerName}\t\t{(product != null ? product.name : "ITEM REMOVED")}\t{quantity}\t{productPrice.ToString("C2")}\t\t{(productPrice * quantity).ToString("C2")}";
        }
    }
}
