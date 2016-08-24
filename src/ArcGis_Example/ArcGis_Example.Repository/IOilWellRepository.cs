using System.Collections.Generic;
using ArcGis_Example.Models;

namespace ArcGis_Example.Repository
{
    public interface IOilWellRepository
    {
        IList<WellLocation> Get();
        IList<Models.WellProduction> GetWellProductionInformation(string wellId);
    }
}