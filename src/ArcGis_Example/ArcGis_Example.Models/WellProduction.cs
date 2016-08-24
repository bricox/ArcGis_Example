using System.Collections.Generic;

namespace ArcGis_Example.Models
{
    public class WellProduction
    {
        public int  Year { get; set; }
        public IList<decimal> Quantity { get; set; }
    }
}
