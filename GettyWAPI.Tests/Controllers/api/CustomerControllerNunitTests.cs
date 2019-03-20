using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using GettyWAPI.Controllers.api;
using NUnit;
using NUnit.Framework;

namespace GettyWAPI.Tests.Controllers.api
{
    [TestFixture]
    public class CustomerControllerNunitTests
    {
        public Customer customer;
        public CustomersController _controller; 

        [SetUp]
        protected void Setup()
        {
            _controller = new CustomersController(new NorthwindEntities());

            customer = new Customer
            {
                CustomerID = "CUST1",
                Address = "2204 244th Ave SW",
                City = "Orville",
                CompanyName = "Thetan Enterprises",
                Country = "USA"
            };
        }

        [Test]
        public void TestCustomerAddress()
        {
            Assert.IsTrue(customer.CustomerID == "CUST1");
            Assert.IsTrue(customer.Country == "USA");
        }

        [Test]
        public void TestGetCustomer()
        {
            // arrange

            // act
            var response = _controller.GetCustomer("ANATR").Result as OkNegotiatedContentResult<Customer>;
            var customer = response.Content;

            // assert
            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<Customer>(customer);
                Assert.IsTrue(customer.ContactTitle == "Owner");
                Assert.IsTrue(customer.Country == "Mexico");
                Assert.IsTrue(customer.Orders.Count == 4);

                // using 'that'
                Assert.That(customer.ContactTitle, Is.EqualTo("Owner"));
                Assert.That(customer.Country, Is.EqualTo("Mexico"));
            });
        }

        [Test]
        public void TestGetCustomers()
        {
            // arrange 

            // act 
            var customers = _controller.GetCustomers(); 

            // assert
            foreach (var customer1 in customers)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(customer1.CustomerID));
            }


            Assert.That(customers.Count(), Is.GreaterThan(1));
        }
    }
}
