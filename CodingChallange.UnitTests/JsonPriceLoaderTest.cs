using CodingChallenge.DataAccess;
using CodingChallenge.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodingChallange.UnitTests
{
    [TestFixture]
    class JsonPriceLoaderTest
    {
        private JsonPriceLoader jpl;


        [Test]
        public void LoadPrice_WithValidPath_ReturnPriceList()
        {
            jpl = new JsonPriceLoader(@"..\..\..\Data\prices.json");
            var list = jpl.LoadPrice();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Is.InstanceOf(typeof(List<Price>)));
        }

        public void LoadPrice_WithInvalidPath_ThrowException()
        {
            jpl = new JsonPriceLoader(@"..\..\..\Data\prices2.json");
            Assert.Throws<FileNotFoundException>(() => jpl.LoadPrice());

        }
    }
}
