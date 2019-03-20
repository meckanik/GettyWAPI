using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GettyWAPI.Models;

namespace GettyWAPI.Repository
{
    public class CustomerRepository
    {
        private NorthwindEntities _context = new NorthwindEntities();

        public async Task<CustomerModel> GetCustomerAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var customer = await _context.Customers.SingleAsync(c => c.CustomerID == id);

            return new CustomerModel
            {
                CustomerId = customer.CustomerID,
                Address = customer.Address,
                City = customer.City,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Country = customer.Country,
                Fax = customer.Fax,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Region = customer.Region
            };
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync()
        {
            return await Task.Run(() => from c in _context.Customers
                select new CustomerModel
                {
                    CustomerId = c.CustomerID,
                    Address = c.Address,
                    City = c.City,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Country = c.Country,
                    Fax = c.Fax,
                    Phone = c.Phone,
                    PostalCode = c.PostalCode,
                    Region = c.Region
                });
        }

        public async Task<CustomerModel> FindCustomer(string id)
        {
            var model = await _context.Customers.SingleAsync(c => c.CustomerID == id);

            return new CustomerModel
            {
                CustomerId = model.CustomerID,
                Address = model.Address,
                City = model.City,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Country = model.Country,
                Fax = model.Fax,
                Phone = model.Phone,
                PostalCode = model.PostalCode,
                Region = model.Region
            };
        }

        public void PutCustomer(CustomerModel model)
        {
            // convert the model
            var result = new Customer
            {
                CustomerID = model.CustomerId, 
                Address = model.Address, 
                City = model.City, 
                CompanyName = model.CompanyName, 
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Country = model.Country,
                Fax = model.Fax,
                Phone = model.Phone,
                PostalCode = model.PostalCode,
                Region = model.Region
            };

            // update the record
            _context.Entry(result).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCustomer(string id)
        {
            var model = new Customer { CustomerID = id} ;
            _context.Customers.Remove(model);
        }


        public async Task<bool> CustomerExistsAsync(string id)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerID == id);
        }
    }
}