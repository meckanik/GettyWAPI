using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettyWAPI.Controllers.api;
using GettyWAPI.Tests.Helpers;
using GettyWAPI.Tests.Helpers.Moq;
using Moq;

namespace GettyWAPI.Tests.Controllers.api
{
    [TestClass]
    public class CustomerControllerMoqTests
    {
        private CustomersController _controller;
        private Mock<NorthwindEntities> MockContext; 

        [TestInitialize]
        public void Setup()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerID = "CUST1",
                    Address = "2204 4th St",
                    City = "Spokane",
                    CompanyName = "Hearlings",
                    ContactName = "Wes Brady",
                    Country = "USA"
                },
                new Customer
                {
                    CustomerID = "CUST2",
                    ContactName = "Jess Beatty",
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            CustomerID = "CUST2",
                            ShipCity = "Spokane"
                        }
                    }
                }
            };

            var queryable = customers.AsQueryable();
            var mockSet = MockAsyncData<Customer>.MockAsyncQueryResult(queryable);

            mockSet.Setup(m => m.Add(It.IsAny<Customer>())).Callback((Customer customer) => customers.Add(customer));
            mockSet.Setup(m => m.Remove(It.IsAny<Customer>())).Callback((Customer customer) => customers.Remove(customer));

            MockContext = new Mock<NorthwindEntities>();
            MockContext.Setup(m => m.Customers).Returns(mockSet.Object);

            _controller = new CustomersController(MockContext.Object);
        }


        [TestMethod]
        public void TestGetCustomer()
        {
            // arrange

            // act
            var response = _controller.GetCustomer("CUST1").Result as OkNegotiatedContentResult<Customer>; ;
            var customer = response.Content;

            // assert
            Assert.IsTrue(customer.CustomerID == "CUST1");

        }

        [TestMethod]
        public void TestGetCustomers()
        {
            // arange

            // act
            var customers = _controller.GetCustomers();

            // assert
            Assert.IsInstanceOfType(customers, typeof(IQueryable<Customer>));
            Assert.IsTrue(customers.Count() == 2);
            Assert.IsTrue(customers.First().CustomerID == "CUST1");

            var customer2 = customers.First(c => c.CustomerID == "CUST2");
            Assert.IsTrue(customer2.Orders.Any());
        }

        [TestMethod]
        public void TestUpdateCustomer()
        {
            // arrange
            var response = _controller.GetCustomer("CUST1").Result as OkNegotiatedContentResult<Customer>;
            var custToUpdate = response.Content;

            custToUpdate.Country = "MEX";

            // act
            var actResult = _controller.PutCustomer(custToUpdate.CustomerID, custToUpdate);
            var response2 = _controller.GetCustomer("CUST1").Result as OkNegotiatedContentResult<Customer>;
            var updatedCust = response2.Content; 

            // assert
            Assert.IsInstanceOfType(updatedCust, typeof(Customer));
            Assert.IsTrue(updatedCust.Country == "MEX");
        }
    }
}
