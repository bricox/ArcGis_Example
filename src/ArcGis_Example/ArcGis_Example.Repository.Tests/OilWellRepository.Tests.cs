using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcGis_Example.Repository.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private IOilWellRepository repository;
        
        [TestInitialize]
        public void Setup()
        {

            var wellLocationData =  @"exceptional_tn_streams.csv";
            var wellProductionData = @"WellProductionExample.csv";
            repository = new OilWellRepository(wellLocationData, wellProductionData);
            
    }

        [TestCleanup]
        public void Cleanup()
        {
            repository = null;
        }

        [TestMethod]
        public void CanIRetrieveAllWells()
        {
            var results = repository.Get();

            Assert.AreEqual(16042, results.Count);
        }

        [TestMethod]
        public void CanIRetrieveTheWellProductionData()
        {
            var wellId = "1245";
            var results = repository.GetWellProductionInformation(wellId);

            Assert.IsNotNull(results);
            Assert.AreEqual(24, results.Count);
            Assert.AreEqual(12, results[0].Quantity.Count);
        }

        [TestMethod]
        public void TestConversion()
        {
            var numberString = "36.500806";
            var numberDecimal = Convert.ToDecimal(numberString);

            Assert.AreEqual(numberString, numberDecimal.ToString());
        }
    }
}
