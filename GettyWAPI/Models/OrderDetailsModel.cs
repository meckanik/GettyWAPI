using System;

namespace GettyWAPI.Models
{
    public class OrderDetailsModel
    {
        public float Discount { get; set; }
        public int OrderId { get; set; }
        public ProductModel Product { get; set; }
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