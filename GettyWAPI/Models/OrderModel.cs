using System;
using System.Collections.Generic;

namespace GettyWAPI.Models
{
    public class OrderModel
    {
        public string CustomerId { get; set; }
        public EmployeeModel Employee { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
        public int OrderId { get; set; }
        public ICollection<OrderDetailsModel> Order_Details { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipName { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipRegion { get; set; }
        public int? ShipVia { get; set; }
        public DateTime? ShippedDate { get; set; }
        public ShipperModel Shipper { get; set; }
    }
}