using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.Data.Models
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }

        public string PONumber { get; set;}

        public DateTime DeliveryDate { get; set;}

        public bool IsDeleted { get; set; } = false;
        public Guid SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier? Supplier { get; set; }

        public virtual ICollection<ProductList>? Products { get; set; }
    }
}
