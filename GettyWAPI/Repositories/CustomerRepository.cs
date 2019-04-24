using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using GettyWAPI.Models;
using GettyWAPI.Models.ModelConverters;

namespace GettyWAPI.Repositories
{
    public class CustomerRepository
    {
        private NorthwindEntities _context;

        public CustomerRepository(NorthwindEntities context)
        {
            _context = context;
        }

        public async Task<CustomerModel> GetCustomerAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var customer = await _context.Customers.SingleAsync(c => c.CustomerID == id);
            var model = CustomerConverter.ConvertToCustomerModel(customer);

            return model;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync()
        {
            return await Task.Run(() =>
                CustomerConverter.ConvertToCustomerModelCollection(_context.Customers)
            );
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

        public void UpdateCustomer(CustomerModel model)
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

        public async Task<int> InsertCustomerAsync(CustomerModel customer)
        {
            var id = Helpers.IdGenerators.GenerateCustomerId(customer);

            var entity = new Customer()
            {
                CustomerID = id,
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

            _context.Customers.Add(entity);

            return await _context.SaveChangesAsync();
        }

        public void DeleteCustomer(string id)
        {
            var model = new Customer { CustomerID = id} ;
            _context.Customers.Remove(model);
            _context.SaveChanges();
        }


        public async Task<bool> CustomerExistsAsync(string id)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerID == id);
        }
    }
}