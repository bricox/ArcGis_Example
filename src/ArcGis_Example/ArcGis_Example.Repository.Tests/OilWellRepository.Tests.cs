using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArcGis_Example.Repository.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private IOilWellRepository repository;
        private string wellLocationData;

        [TestInitialize]
        public void Setup()
        {
            wellLocationData =  @"exceptional_tn_streams.csv";
            repository = new OilWellRepository(wellLocationData);
            
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
        public void TestConversion()
        {
            var numberString = "36.500806";
            var numberDecimal = Convert.ToDecimal(numberString);

            Assert.AreEqual(numberString, numberDecimal.ToString());
        }
    }
}
