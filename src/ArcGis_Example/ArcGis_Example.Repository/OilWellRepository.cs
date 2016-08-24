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
        private string _wellProductionFilePath;

        public OilWellRepository(string wellLocationFilePath, string wellProductionFilePath)
        {
            _wellLocationFilePath = wellLocationFilePath;
            _wellProductionFilePath = wellProductionFilePath;
        }



        public IList<Models.WellLocation> Get()
        {
            Decimal tmpDec;

            var wellData = System.IO.File.ReadAllLines(_wellLocationFilePath);

            return wellData.Select(p =>
            {
                var columns = splitLines(p);
                
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

        public IList<Models.WellProduction> GetWellProductionInformation(string wellId)
        {
            var productionData = System.IO.File.ReadAllLines(_wellProductionFilePath);

            return productionData.Select(p =>
            {
                var columns = p.Split(',');

                var quantities = Enumerable.Range(1, 12)
                    .Select(q => Convert.ToDecimal(columns[q])).ToArray();

                return new Models.WellProduction
                {
                    Year = Convert.ToInt32(columns[0]),
                    Quantity = quantities
                };
            }).ToList();
        }

        private string[] splitLines(string line)
        {
            string[] seps = { "\",", ",\"" };
            char[] quotes = { '\"', ' ' };

            return line
                    .Split(seps, StringSplitOptions.None)
                    .Select(s => s.Trim(quotes).Replace("\\\"", "\""))
                    .ToArray();
        }
    }
}
