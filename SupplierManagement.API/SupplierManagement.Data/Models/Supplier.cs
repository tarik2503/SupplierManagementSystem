using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.Data.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string SupplierName { get; set; }
        public string ImgPath { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Street {  get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Product>? Products { get; set; }

        public virtual ICollection<PurchaseOrder>? PurchaseOrders { get; set; }

    }
}
