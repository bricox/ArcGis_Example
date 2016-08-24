﻿using ArcGis_Example.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArcGis_Example.ViewModels;

namespace ArcGis_Example.Controllers
{
    [AllowAnonymous]
    public class WellController : ApiController
    {
        private OilWellRepository wellRepository;

        public WellController()
        {
            var wellDataFilePath = System.Web.HttpContext.Current.Request.MapPath(@"~/exceptional_tn_streams.csv");
            wellRepository = new OilWellRepository(wellDataFilePath);
        }

        [Filters.ExceptionFilter]
        public IHttpActionResult Get()
        {
            var wells = wellRepository.Get();

            var wellViewModels = wells.Select(p => new ArcGisLocation
            {
                x = p.Latitude,
                y = p.Longitude,
                SpatialReference = new SpatialReference { Wkid = "4326" }
            }).ToList();

            return Ok(wellViewModels);
        }
    }
}