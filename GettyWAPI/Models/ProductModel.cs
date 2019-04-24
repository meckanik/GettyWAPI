using System.Collections.Generic;

namespace GettyWAPI.Models
{
    public class ProductModel
    {
        public CatagoryModel Catagory { get; set; }
        public int? CatagoryId { get; set; }
        public bool Discontinued { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int? ReorderLevel { get; set; }
        public SupplierModel Supplier { get; set; }
        public int? SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
    }
}