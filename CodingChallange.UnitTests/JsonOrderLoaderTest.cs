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
    class JsonOrderLoaderTest
    {
        private JsonOrderLoader jpl;


        [Test]
        public void LoadOrder_WithValidPath_ReturnPriceList()
        {
            jpl = new JsonOrderLoader(@"..\..\..\Data\orders.json");
            var list = jpl.LoadOrder();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Is.InstanceOf(typeof(List<Order>)));
        }
        [Test]
        public void LoadOrder_WithInvalidPath_ThrowException()
        {
            jpl = new JsonOrderLoader(@"..\..\..\Data\orders2.json");
            Assert.Throws<FileNotFoundException>(() => jpl.LoadOrder());

        }
    }
}
