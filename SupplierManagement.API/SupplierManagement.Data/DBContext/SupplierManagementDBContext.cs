using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupplierManagement.Data.Configuration;
using SupplierManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.Data.DBContext
{
    public class SupplierManagementDBContext:IdentityDbContext<User>
    {
        public SupplierManagementDBContext(DbContextOptions<SupplierManagementDBContext> options): base(options)
        {
            
        }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<ProductList> ProductLists { get; set; }
        public DbSet<LastPONumber> LastPONumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            modelBuilder.Entity<LastPONumber>().HasData(new LastPONumber { Id = 1, LastNumber = 1000 });

            modelBuilder.Entity<ProductList>()
       .HasOne(pl => pl.PurchaseOrder)
       .WithMany(po => po.Products)
       .HasForeignKey(pl => pl.PurchaseOrderId)
       .OnDelete(DeleteBehavior.Restrict); // Specify ON DELETE NO ACTION
        }
    }
}
