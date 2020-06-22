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
    class JsonPaymentLoaderTest
    {
        private JsonPaymentLoader jpl;

        [Test]
        public void LoadPayment_WithValidPath_ReturnPaymentList()
        {
            jpl = new JsonPaymentLoader(@"..\..\..\Data\payments.json");
            var list = jpl.LoadPayment();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Is.InstanceOf(typeof(List<Payment>)));
        }

        public void LoadPayment_WithInvalidPath_ThrowException()
        {
            jpl = new JsonPaymentLoader(@"..\..\..\Data\prices2.json");
            Assert.Throws<FileNotFoundException>(() => jpl.LoadPayment());

        }
    }
}
