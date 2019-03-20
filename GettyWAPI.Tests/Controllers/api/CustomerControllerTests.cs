using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using GettyWAPI.Controllers.api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GettyWAPI.Tests.Controllers.api
{
    [TestClass]
    public class CustomerControllerTests
    {
        private CustomersController _controller;

        [TestInitialize]
        public void Setup()
        {
            var context = new NorthwindEntities();
            _controller = new CustomersController(context);
        }

        [TestMethod]
        public void GetCustomersTest()
        {
            // ARRANGE

            // ACT
            var result = _controller.GetCustomers();

            // ASSERT
            Assert.IsInstanceOfType(result, typeof(IQueryable<Customer>));
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCustomerTest()
        {
            // Arrange

            // Act
            var data = _controller.GetCustomer("ANATR").Result as OkNegotiatedContentResult<Customer>;
            var result = data.Content;

            // Assert
            Assert.IsTrue(result.ContactName == "Ana Trujillo");
        }
    }
}
