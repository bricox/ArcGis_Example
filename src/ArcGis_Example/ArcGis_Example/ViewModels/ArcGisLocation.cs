using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcGis_Example.ViewModels
{
    public class ArcGisLocation
    {
        public decimal? x { get; set; }
        public decimal? y { get; set; }

        public SpatialReference SpatialReference { get; set; }

    }

    public class SpatialReference
    {
        public string Wkid { get; set; }
    }
}