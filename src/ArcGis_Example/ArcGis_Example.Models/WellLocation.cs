using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGis_Example.Models
{
    public class WellLocation
    {
        //"County","EFO Name","Permit Date","Permit No","API No","Operator Name","Well Name and Number","Latitude","Longitude","Elevation","Formation at Total Depth","Purpose af Well"

        public string County { get; set; }
        public string  City { get; set; }
        public string PermitDate { get; set; }
        public string PermitNumber { get; set; }
        public string OperatorName { get; set; }
        public string WellName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }


    }
}
