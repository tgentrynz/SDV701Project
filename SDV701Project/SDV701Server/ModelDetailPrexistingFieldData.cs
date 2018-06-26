using System.Collections.Generic;

namespace SDV701Server
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// For use in the admin app. Stores pre-exisitng values for computer editing fields.
    /// </summary>
    public class ModelDetailPrexistingFieldData
    {
        public List<string> OperatingSystems { get; set; }
        public List<string> ProcessorFamilies { get; set; }
        public List<string> GraphicsFamilies { get; set; }
        public List<string> TowerForms { get; set; }
    }
}
