using CodingChallenge.DataProcessor;
using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using CodingChallenge.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CodingChallange.UnitTests
{
    [TestFixture]
    public class CafeShopTest
    {
        private CafeShop cafeShop;
        [SetUp]
        public void Setup()
        {
            Mock<IOrderProcessor> mockOrderProcessor = new Mock<IOrderProcessor>();
            Mock<IPaymentProcessor> mockPaymentProcessor = new Mock<IPaymentProcessor>();
            cafeShop = new CafeShop(mockOrderProcessor.Object, mockPaymentProcessor.Object);
        }
        [Test]
        public void FindCoffeeFromShopsSelectionFor_WithNull_ReturnNullCoffee()
        {
            cafeShop.InitializeCoffeeSelection(new List<Coffee>() { new Latte("latte", "small", 3), new Mocha("mocha", "large", 4) });
            var result = cafeShop.FindCoffeeFromShopsSelectionFor(null);
            Assert.That(result, Is.InstanceOf(typeof(NullCoffee)));
        }

        [Test]
        public void FindCoffeeFromShopsSelectionFor_WithOnlySize_ReturnNullCoffee()
        {
            cafeShop.InitializeCoffeeSelection(new List<Coffee>() { new Latte("latte", "small", 3), new Mocha("mocha", "large", 4) });
            Order order = new Order() { size="small"};

            var result = cafeShop.FindCoffeeFromShopsSelectionFor(order);
            Assert.That(result, Is.InstanceOf(typeof(NullCoffee)));
        }
        [Test]
        public void FindCoffeeFromShopsSelectionFor_WithOnlyDrink_ReturnNullCoffee()
        {

            cafeShop.InitializeCoffeeSelection(new List<Coffee>() { new Latte("latte", "small", 3), new Mocha("mocha", "large", 4) });
            Order order = new Order() { drink = "mocha" };

            var result = cafeShop.FindCoffeeFromShopsSelectionFor(order);
            Assert.That(result, Is.InstanceOf(typeof(NullCoffee)));
        }
        [Test]
        public void FindCoffeeFromShopsSelectionFor_WithDrinkAndSize_ReturnLatteCoffee()
        {
            cafeShop.InitializeCoffeeSelection(new List<Coffee>() { new Latte("latte", "small", 3), new Mocha("mocha", "large", 4) });
            
            Order order = new Order() { drink = "latte" , size = "small"};

            var result = cafeShop.FindCoffeeFromShopsSelectionFor(order);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(Latte)));
        }

        [Test]
        public void FindCustomerFromBy_WithNull_ReturnNull()
        {
            cafeShop.InitializeCoffeeSelection(new List<Coffee>() { new Latte("latte", "small", 3), new Mocha("mocha", "large", 4) });

            Order order = new Order() { drink = "latte", size = "small" };

            var result = cafeShop.FindCoffeeFromShopsSelectionFor(order);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(Latte)));
        }

        [Test]
        public void CreateNewCustomer_WithEmptyList_ReturnCustomerWithNoOrders()
        {
            cafeShop.InitializeCoffeeSelection(new List<Coffee>() { new Latte("latte", "small", 3), new Mocha("mocha", "large", 4) });

            var result = cafeShop.CreateNewCustomer("test",null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(Customer)));
            Assert.That(result.GetAllOrders().Count, Is.EqualTo(0));
        }

        [Test]
        public void CreateNewCustomer_WithInvalidCoffeeName_ReturnCustomerWithNoOrders()
        {
            cafeShop.InitializeCoffeeSelection(new List<Coffee>() { new Latte("latte", "small", 3), new Mocha("mocha", "large", 4) });
            var orderList = new List<Order>() { new Order() { user = "testuser", drink = "invalidCoffee", size = "small" } };
            var result = cafeShop.CreateNewCustomer("test", orderList);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(Customer)));
            Assert.That(result.GetAllOrders().Count, Is.EqualTo(0));
        }

        [Test]
        public void CreateNewCustomer_WithValidList_ReturnCustomerWithNoOrders()
        {
            cafeShop.InitializeCoffeeSelection(new List<Coffee>() { new Latte("latte", "small", 3), new Mocha("mocha", "large", 4) });
            var orderList = new List<Order>() { new Order() { user = "testuser", drink = "latte", size = "small" } };
            var result = cafeShop.CreateNewCustomer("test", orderList);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(Customer)));
            Assert.That(result.GetAllOrders().Count, Is.EqualTo(1));
            Assert.That(result.GetAllOrders()[0], Is.InstanceOf(typeof(Latte)));

        }   
        
    }
}
