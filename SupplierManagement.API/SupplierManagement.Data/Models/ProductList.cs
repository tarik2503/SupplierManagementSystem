using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.Data.Models
{
    public class ProductList
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }

        public bool IsDeleted { get; set; } = false;

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public Guid PurchaseOrderId { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public virtual PurchaseOrder? PurchaseOrder { get; set; }

    }
}
