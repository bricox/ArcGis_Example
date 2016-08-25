using ArcGis_Example.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArcGis_Example.ViewModels;
using ArcGis_Example.Filters;

namespace ArcGis_Example.Controllers
{
    [AllowAnonymous]
    public class WellController : ApiController
    {
        private OilWellRepository wellRepository;

        public WellController()
        {
            var wellDataFilePath = System.Web.HttpContext.Current.Request.MapPath(@"~/exceptional_tn_streams.csv");
            var wellProductionFilePath = System.Web.HttpContext.Current.Request.MapPath(@"~/WellProductionExample.csv");
            wellRepository = new OilWellRepository(wellDataFilePath, wellProductionFilePath);
        }

        [ExceptionFilter]
        public IHttpActionResult Get()
        {
            var wells = wellRepository.Get();

            var wellViewModels = wells.Where(p=>p.Latitude != null && p.Longitude != null).Select(p => new ArcGisLocation
            {
                y = p.Latitude,
                x = p.Longitude,
                SpatialReference = new SpatialReference { Wkid = "4326" }
            }).ToList();

            return Ok(wellViewModels);
        }

        [ExceptionFilter]
        public IHttpActionResult Get(string id)
        {
            return Ok(wellRepository.GetWellProductionInformation(id));
        }
    }
}
