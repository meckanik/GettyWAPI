using System.Collections.Generic;
using System.Linq;

namespace GettyWAPI.Models.ModelConverters
{
    public class CustomerConverter
    {
        public static CustomerModel ConvertToCustomerModel(Customer customer)
        {
            return convertToCustomerModel(customer);
        }

        public static ICollection<CustomerModel> ConvertToCustomerModelCollection(IEnumerable<Customer> customers)
        {
            var customerModels = new List<CustomerModel>();

            foreach (var customer in customers)
            {
                customerModels.Add(convertToCustomerModel(customer));
            }

            return customerModels;
        }

        private static CustomerModel convertToCustomerModel(Customer customer)
        {
            return new CustomerModel
            {
                CustomerId = customer.CustomerID,
                Address = customer.Address,
                City = customer.City,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Country = customer.Country,
                //CustomerDemographics = (from c in customer.CustomerDemographics
                //                        select new CustomerDemographicModel
                //                        {
                //                            CustomerDesc = c.CustomerDesc,
                //                            CustomerTypeId = c.CustomerTypeID
                //                        }).ToArray(),
                Fax = customer.Fax,
                //Orders = (from o in customer.Orders
                //          select new OrderModel
                //          {
                //              CustomerId = o.CustomerID,
                //              Employee = new EmployeeModel
                //              {
                //                  Address = o.Employee.Address,
                //                  BirthDate = o.Employee.BirthDate ?? null,
                //                  City = o.Employee.City,
                //                  Country = o.Employee.Country,
                //                  EmployeeId = o.Employee.EmployeeID,
                //                  Extension = o.Employee.Extension,
                //                  FirstName = o.Employee.FirstName,
                //                  HireDate = o.Employee.HireDate ?? null,
                //                  HomePhone = o.Employee.HomePhone,
                //                  LastName = o.Employee.LastName,
                //                  Notes = o.Employee.Notes,
                //                  PhotoPath = o.Employee.PhotoPath,
                //                  PostalCode = o.Employee.PostalCode,
                //                  Region = o.Employee.Region,
                //                  ReportsTo = o.Employee.ReportsTo ?? null,
                //                  Territories = (from t in o.Employee.Territories
                //                                 select new TerritoryModel
                //                                 {
                //                                     Region = new RegionModel
                //                                     {
                //                                         RegionDescription = t.Region.RegionDescription,
                //                                         RegionId = t.Region.RegionID
                //                                     },
                //                                     RegionId = t.RegionID,
                //                                     TerritoryDescription = t.TerritoryDescription,
                //                                     TerritoryId = t.TerritoryID
                //                                 }).ToArray()
                //              },
                //              EmployeeId = o.EmployeeID ?? null,
                //              Freight = o.Freight ?? null,
                //              OrderDate = o.OrderDate ?? null,
                //              OrderId = o.OrderID,
                //              Order_Details = (from detail in o.Order_Details
                //                               select new OrderDetailsModel
                //                               {
                //                                   Discount = detail.Discount,
                //                                   OrderId = detail.OrderID,
                //                                   Product = new ProductModel
                //                                   {
                //                                       Catagory = new CatagoryModel
                //                                       {
                //                                           CatagoryId = detail.Product.Category.CategoryID,
                //                                           CatagoryName = detail.Product.Category.CategoryName,
                //                                           Description = detail.Product.Category.Description
                //                                       },
                //                                       CatagoryId = detail.Product.CategoryID,
                //                                       Discontinued = detail.Product.Discontinued,
                //                                       ProductId = detail.Product.ProductID,
                //                                       ProductName = detail.Product.ProductName,
                //                                       QuantityPerUnit = detail.Product.QuantityPerUnit,
                //                                       ReorderLevel = detail.Product.ReorderLevel ?? null,

                //                                       Supplier = new SupplierModel
                //                                       {
                //                                           Address = detail.Product.Supplier.Address,
                //                                           City = detail.Product.Supplier.City,
                //                                           CompanyName = detail.Product.Supplier.CompanyName,
                //                                           ContactName = detail.Product.Supplier.ContactName,
                //                                           ContactTitle = detail.Product.Supplier.ContactTitle,
                //                                           Country = detail.Product.Supplier.Country,
                //                                           Fax = detail.Product.Supplier.Fax,
                //                                           HomePage = detail.Product.Supplier.HomePage,
                //                                           Phone = detail.Product.Supplier.Phone,
                //                                           PostalCode = detail.Product.Supplier.PostalCode,
                //                                           Region = detail.Product.Supplier.Region,
                //                                           SupplierId = detail.Product.Supplier.SupplierID
                //                                       },
                //                                       SupplierId = detail.Product.SupplierID,
                //                                       UnitPrice = detail.Product.UnitPrice ?? null,
                //                                       UnitsInStock = detail.Product.UnitsInStock ?? null,
                //                                       UnitsOnOrder = detail.Product.UnitsOnOrder ?? null
                //                                   },
                //                                   RequiredDate = o.RequiredDate ?? null,
                //                                   ShipAddress = o.ShipAddress,
                //                                   ShipCity = o.ShipCity,
                //                                   ShipCountry = o.ShipCountry,
                //                                   ShipName = o.ShipName,
                //                                   ShippedDate = o.ShippedDate ?? null,
                //                                   Shipper = new ShipperModel
                //                                   {
                //                                       CompanyName = o.Shipper.CompanyName,
                //                                       Phone = o.Shipper.Phone,
                //                                       ShipperId = o.Shipper.ShipperID
                //                                   },
                //                                   ShipPostalCode = o.ShipPostalCode,
                //                                   ShipRegion = o.ShipRegion,
                //                                   ShipVia = o.ShipVia ?? null
                //                               }).ToArray()
                //          }).ToArray(),
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Region = customer.Region
            };
        }
    }
}