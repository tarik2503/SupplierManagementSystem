using Microsoft.EntityFrameworkCore;
using SupplierManagement.API.IRepository;
using SupplierManagement.Data.DBContext;
using SupplierManagement.Data.Models;

namespace SupplierManagement.API.Repository
{
    public class SupplierRepo : ISupplier
    {
        private readonly SupplierManagementDBContext _context;

        public SupplierRepo(SupplierManagementDBContext _context)
        {
            this._context = _context;
        }

        public async Task<Supplier> GetSupplier(Guid suppId)
        {

            return await _context.Suppliers
               .FirstOrDefaultAsync(e => e.Id == suppId);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers(string userId)
        {

            return await _context.Suppliers.Where(x => x.UserId == userId && x.IsDeleted == false).ToListAsync();

        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            var result = await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            var result = await _context.Suppliers
                .FirstOrDefaultAsync(e => e.Id == supplier.Id);

            if (result != null)
            {
                result.SupplierName = supplier.SupplierName;
                result.ImgPath = supplier.ImgPath;
                result.Email = supplier.Email;
                result.Phone = supplier.Phone;
                result.City = supplier.City;
                result.Country = supplier.Country;
                result.State = supplier.State;
                result.ZipCode = supplier.ZipCode;
                result.Street = supplier.Street;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Supplier> DeleteSupplier(Guid suppId)
        {
            var result = await _context.Suppliers
                .FirstOrDefaultAsync(e => e.Id == suppId);
            if (result != null)
            {
                result.IsDeleted = true;

                //Do IsDeleted true for the products related to this supplier
                await _context.Products
                  .Where(p => p.SupplierId == result.Id)
                  .ForEachAsync(p => p.IsDeleted = true);

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
