using System;
using System.Collections.Generic;
namespace SDV701Server
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Represents a purchase order data entity.
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

        public Dictionary<String, Object> toParameterList()
        {
            return new Dictionary<String, Object>()
            {
                { "product", product.name},
                { "customerName", customerName},
                { "customerStreetAddress", customerStreetAddress},
                { "customerCity", customerCity},
                { "customerPostCode", customerPostCode},
                { "productPrice", product.price},
                { "quantity", quantity}
            };
        }
    }
}
