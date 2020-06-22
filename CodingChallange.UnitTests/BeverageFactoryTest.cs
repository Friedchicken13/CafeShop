using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallange.UnitTests
{
    [TestFixture]
    class BeverageFactoryTest
    {
        private BeverageFactory beverageFactory;
        List<Price> priceList;

        [SetUp]
        public void Setup()
        {
            beverageFactory = new BeverageFactory();
            priceList = new List<Price>();

        }

        [Test]
        public void CreateCoffees_WithNull_ReturnEmptyList()
        {
            var result = beverageFactory.CreateCoffees(null);
            Assert.That(result, Is.Empty);
        
        }

        [Test]
        public void CreateCoffees_WithEmptyList_ReturnEmptyList()
        {
            priceList = new List<Price>();
            var result = beverageFactory.CreateCoffees(priceList);
            Assert.That(result, Is.Empty);

        }

        [Test]
        public void CreateCoffees_WithShortEspresso_ReturnShortEspressoList()
        {
            priceList = new List<Price>();
            priceList.Add(new Price() { drink_name = "short espresso", prices = new Dictionary<string, decimal> { { "small", 13 } } });

            var result = beverageFactory.CreateCoffees(priceList);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0], Is.InstanceOf(typeof(ShortEspresso)));

        }

        [Test]
        public void CreateCoffees_WithLatte_ReturnLatteList()
        {
            priceList = new List<Price>();
            priceList.Add(new Price() { drink_name = "latte", prices = new Dictionary<string, decimal> { { "medium", 14 } } });

            var result = beverageFactory.CreateCoffees(priceList);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0], Is.InstanceOf(typeof(Latte)));

        }

        [Test]
        public void CreateCoffees_WithFlatWhite_ReturnFlatWhiteList()
        {
            priceList = new List<Price>();
            priceList.Add(new Price() { drink_name = "flat white", prices = new Dictionary<string, decimal> { { "large", 15 } } });

            var result = beverageFactory.CreateCoffees(priceList);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0], Is.InstanceOf(typeof(FlatWhite)));

        }

        [Test]
        public void CreateCoffees_WithLongBlack_ReturnLongBlackList()
        {
            priceList = new List<Price>();
            priceList.Add(new Price() { drink_name = "long black", prices = new Dictionary<string, decimal> { { "mega", 16 } } });

            var result = beverageFactory.CreateCoffees(priceList);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0], Is.InstanceOf(typeof(LongBlack)));

        }

        [Test]
        public void CreateCoffees_WithMocha_ReturnMochaList()
        {
            priceList = new List<Price>();
            priceList.Add(new Price() { drink_name = "mocha", prices = new Dictionary<string, decimal> { { "ultra", 17 } } });

            var result = beverageFactory.CreateCoffees(priceList);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0], Is.InstanceOf(typeof(Mocha)));

        }

        [Test]
        public void CreateCoffees_Withsupermochacrapucaramelcream_ReturnSupermochacrapucaramelcreamList()
        {
            priceList = new List<Price>();
            priceList.Add(new Price() { drink_name = "supermochacrapucaramelcream", prices = new Dictionary<string, decimal> { { "small", 18 } } });

            var result = beverageFactory.CreateCoffees(priceList);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0], Is.InstanceOf(typeof(SuperMochacrapuCaramelCream)));

        }

        [Test]
        public void CreateCoffees_WithInvalidCoffee_ReturnNullCoffeeList()
        {
            priceList = new List<Price>();
            priceList.Add(new Price() { drink_name = "invalidcoffee", prices = new Dictionary<string, decimal> { { "smalls", 99 } } });

            var result = beverageFactory.CreateCoffees(priceList);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0], Is.InstanceOf(typeof(NullCoffee)));

        }
    }
}
