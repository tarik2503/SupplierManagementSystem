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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
