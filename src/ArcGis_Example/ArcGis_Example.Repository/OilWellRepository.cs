using ArcGis_Example.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ArcGis_Example.Repository
{
    public class OilWellRepository : IOilWellRepository
    {
        //private string wellLocationData = HttpContext.Current.Server.MapPath("~/exceptional_tn_stream.csv");

        //"County","EFO Name","Permit Date","Permit No","API No","Operator Name","Well Name and Number","Latitude","Longitude","Elevation","Formation at Total Depth","Purpose af Well"
        private string _wellLocationFilePath;

        public OilWellRepository(string wellLocationFilePath)
        {
            _wellLocationFilePath = wellLocationFilePath;
        }



        public IList<Models.WellLocation> Get()
        {
            string[] seps = { "\",", ",\"" };
            char[] quotes = { '\"', ' ' };
            Decimal tmpDec;

            var wellData = System.IO.File.ReadAllLines(_wellLocationFilePath);

            return wellData.Select(p =>
            {
                var columns = p
                    .Split(seps, StringSplitOptions.None)
                    .Select(s => s.Trim(quotes).Replace("\\\"", "\""))
                    .ToArray();

                
                return new Models.WellLocation
                {
                    County = columns[0].RemoveQuotes(),
                    City = columns[1].RemoveQuotes(),
                    PermitDate = columns[2].RemoveQuotes(),
                    PermitNumber = columns[3].RemoveQuotes(),
                    OperatorName = columns[5].RemoveQuotes(),
                    WellName = columns[6].RemoveQuotes(),
                    Latitude = (Decimal.TryParse(columns[7].RemoveQuotes(), out tmpDec) ? tmpDec : (Decimal?) null),
                    Longitude = (Decimal.TryParse(columns[8].RemoveQuotes(), out tmpDec) ? tmpDec : (Decimal?)null)

                };

            }).ToList();
        }
    }
}
