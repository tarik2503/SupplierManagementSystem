using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string ProductSKU { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier? Supplier { get; set; }
    }

    
}
