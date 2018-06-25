using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDV701Server
{
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
