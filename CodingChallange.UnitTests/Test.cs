using CodingChallenge.DataProcessor;
using CodingChallenge.DataAccess;
using CodingChallenge.Models;
using CodingChallenge.Models.CoffeeSelection;
using CodingChallenge.Services;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallange.UnitTests
{
    [TestFixture]
    class Test
    {
        private ICafeShop myCafeShop;

        [SetUp]
        public void Setup()
        {
            IPriceProcessor myJsonPriceProcessor = new JsonPriceProcessor(new BeverageFactory(), new JsonPriceLoader(@"..\..\..\Data\prices.json"));
            IOrderProcessor myJsonOrderProcessor = new JsonOrderProcessor(new JsonOrderLoader(@"..\..\..\Data\orders.json"));
            IPaymentProcessor myJsonPaymentProcessor = new JsonPaymentProcessor(new JsonPaymentLoader(@"..\..\..\Data\payments.json"));

            myCafeShop = new CafeShop(myJsonOrderProcessor,myJsonPaymentProcessor);

            List<Coffee> coffeeList = myJsonPriceProcessor.ProcessInputPrice();

            myCafeShop.InitializeCoffeeSelection(coffeeList);
            myCafeShop.LoadOrders();
            myCafeShop.UpdateCustomersBalance();
        }

        [Test]
        public void HasUsersWhoOrderedCoffee()
        {
            Assert.That(myCafeShop.GetCustomerList().Count.Equals(4));
            Assert.That(myCafeShop.GetCustomerList()[0].GetName().Equals("coach"));
            Assert.That(myCafeShop.GetCustomerList()[1].GetName().Equals("ellis"));
            Assert.That(myCafeShop.GetCustomerList()[2].GetName().Equals("rochelle"));
            Assert.That(myCafeShop.GetCustomerList()[3].GetName().Equals("zoey"));
        }

        [Test]
        public void OutputJSONInExpectedFormForFirstCustomer()
        {
            IResultProvider resultProvider = new ResultProvider();
            var result = resultProvider.ComposeResult(new List<Customer>() { myCafeShop.GetCustomerList()[0] });
            var expectedResult = "[\r\n  {\r\n    \"user\": \"coach\",\r\n    \"order_total\": 8.00,\r\n    \"payment_total\": 2.50,\r\n    \"balance\": 5.50\r\n  }\r\n]";

            Assert.That(JToken.DeepEquals(result, expectedResult),Is.True);
        }

        [Test]
        public void OutputJSONInExpectedFormForSecondCustomer()
        {
            IResultProvider resultProvider = new ResultProvider();
            var result = resultProvider.ComposeResult(new List<Customer>() { myCafeShop.GetCustomerList()[1] });
            var expectedResult = "[\r\n  {\r\n    \"user\": \"ellis\",\r\n    \"order_total\": 3.25,\r\n    \"payment_total\": 3.25,\r\n    \"balance\": 0.00\r\n  }\r\n]";
          
            Assert.That(JToken.DeepEquals(result, expectedResult), Is.True);
        }

        [Test]
        public void OutputJSONInExpectedFormForThirdCustomer()
        {
            IResultProvider resultProvider = new ResultProvider();
            var result = resultProvider.ComposeResult(new List<Customer>() { myCafeShop.GetCustomerList()[2] });
            var expectedResult = "[\r\n  {\r\n    \"user\": \"rochelle\",\r\n    \"order_total\": 4.50,\r\n    \"payment_total\": 4.50,\r\n    \"balance\": 0.00\r\n  }\r\n]";

            Assert.That(JToken.DeepEquals(result, expectedResult), Is.True);
        }

        [Test]
        public void OutputJSONInExpectedFormForForthCustomer()
        {
            IResultProvider resultProvider = new ResultProvider();
            var result = resultProvider.ComposeResult(new List<Customer>() { myCafeShop.GetCustomerList()[2] });
            var expectedResult = "[\r\n  {\r\n    \"user\": \"rochelle\",\r\n    \"order_total\": 4.50,\r\n    \"payment_total\": 4.50,\r\n    \"balance\": 0.00\r\n  }\r\n]";

            Assert.That(JToken.DeepEquals(result, expectedResult), Is.True);
        }

        [Test]
        public void HasOrderTotalsForUsers()
        {
            var allUserBalanceList = myCafeShop.GetAllUsersBalanceList();
            Assert.That(Math.Abs(allUserBalanceList[0].GetOrderTotal()- 8M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[1].GetOrderTotal() - 3.25M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[2].GetOrderTotal() - 4.50M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[3].GetOrderTotal() - 6.53M), Is.LessThan(0.0001M));

        }

        [Test]
        public void HasPaymentTotalsForUsers()
        {
            var allUserBalanceList = myCafeShop.GetAllUsersBalanceList();
            Assert.That(Math.Abs(allUserBalanceList[0].GetPaymentTotal() - 2.50M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[1].GetPaymentTotal() - 3.25M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[2].GetPaymentTotal() - 4.50M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[3].GetPaymentTotal() - 0.00M), Is.LessThan(0.0001M));            
        }

        [Test]
        public void HasCurrentBalanceForUsers()
        {
            var allUserBalanceList = myCafeShop.GetAllUsersBalanceList();
            Assert.That(Math.Abs(allUserBalanceList[0].GetCurrentBalance() - 5.50M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[1].GetCurrentBalance() - 0.00M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[2].GetCurrentBalance() - 0.00M), Is.LessThan(0.0001M));
            Assert.That(Math.Abs(allUserBalanceList[3].GetCurrentBalance() - 6.53M), Is.LessThan(0.0001M));
        }
    }
}
