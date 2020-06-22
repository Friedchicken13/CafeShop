using CodingChallenge.DataProcessor;
using CodingChallenge.DataAccess;
using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using CodingChallenge.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;

namespace CodingChallange.UnitTests
{
    [TestFixture]
    public class JsonOrderProcessorTest
    {
        private JsonOrderProcessor jsonOrderProcessor;
        [SetUp]
        public void Setup()
        {
            jsonOrderProcessor = new JsonOrderProcessor(new JsonOrderLoader(@"..\..\..\Data\orders.json"));
        }

        [Test]
        public void LoadOrders_WithValidPath_ReturnOrderList()
        {
            jsonOrderProcessor.LoadOrders();
            Assert.That(jsonOrderProcessor.GetAllOrders(), Is.Not.Null);
            Assert.That(jsonOrderProcessor.GetAllOrders(), Is.Not.Empty);
            Assert.That(jsonOrderProcessor.GetAllOrders(), Is.InstanceOf(typeof(List<Order>)));
        }      

        [Test]
        public void GetAllCustomers_WithValidOrderList_ReturnList()
        {
            jsonOrderProcessor.LoadOrders();
            var t = jsonOrderProcessor.GetAllCustomers();
            Assert.That(t, Is.Not.Null);
            Assert.That(t, Is.Unique);
            Assert.That(t, Is.InstanceOf(typeof(string[])));
        }

        [Test]
        public void GetAllOrdersFrom_ValidCustomer_ReturnList()
        {
            var customer = "coach";
            jsonOrderProcessor.LoadOrders();
            var t = jsonOrderProcessor.GetAllOrdersFrom(customer);
            Assert.That(t, Is.Not.Null);
            Assert.That(t, Is.InstanceOf(typeof(List<Order>)));
            Assert.AreEqual(t[0].user, customer);
        }

        //public List<Order> GetAllOrdersFrom(string user)
        //{
        //    return orderList.Where(t => t.user == user).ToList();
        //}


        //[Test]
        //public void GetAllCustomers_WithValidImput_ReturnList()
        //{
        //    jsonOrderProcessor.LoadOrders();

        //    var result = jsonOrderProcessor.GetAllCustomers();

        //    Assert.That(result, Is.Not.Null);
        //}

        //[Test]
        //public void ProcessInputPrice_WithEmptyCoffeeList_ReturnValidList()
        //{

        //    jsonOrderProcessor.LoadOrders(); 

        //    var result = jsonOrderProcessor.GetAllOrdersFrom("ellis");

        //    Assert.That(result, Is.Not.Null);
        //}

    }
}
