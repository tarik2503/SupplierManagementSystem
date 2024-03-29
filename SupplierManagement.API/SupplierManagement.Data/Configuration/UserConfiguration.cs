using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
     new User()
     {
         Id = "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
         UserName = "user@gmail.com",
         FirstName = "User",
         LastName = "User",
         Email = "user@gmail.com",
         EmailConfirmed = true,
         NormalizedEmail = "user@gmail.com",
         PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "User@123")

     },
     new User()
     {
         Id = "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
         UserName = "admin@gmail.com",
         FirstName = "Admin",
         LastName = "Admin",
         Email = "admin@gmail.com",
         EmailConfirmed = true,
         NormalizedEmail = "admin@gmail.com",
         PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Admin@123")

     });
        }
    }
}
