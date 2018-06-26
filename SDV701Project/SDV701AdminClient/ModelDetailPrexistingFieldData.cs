using System.Collections.Generic;


namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Contains preloaded information for auto-filling computer detail fields.
    /// </summary>
    public class ModelDetailPrexistingFieldData
    {
        public List<string> OperatingSystems { get; set; }
        public List<string> ProcessorFamilies { get; set; }
        public List<string> GraphicsFamilies { get; set; }
        public List<string> TowerForms { get; set; }
    }
}
