using CodingChallenge.DataProcessor;
using CodingChallenge.DataAccess;
using CodingChallenge.Models;
using CodingChallenge.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;

namespace CodingChallange.UnitTests
{
    [TestFixture]
    public class JsonPriceProcessorTest
    {

        [Test]
        public void ProcessInputPrice_WithValidPath_ReturnList()
        {
            var jsonPriceProcessor = new JsonPriceProcessor(new BeverageFactory(), new JsonPriceLoader(@"..\..\..\Data\prices.json"));

            var result = jsonPriceProcessor.ProcessInputPrice();

            Assert.That(result,Is.Not.Null);
        }
    }
}