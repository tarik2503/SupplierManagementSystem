using SupplierManagement.Data.Models;

namespace SupplierManagement.API.IRepository
{
    public interface ISupplier
    {
        Task<IEnumerable<Supplier>> GetSuppliers(string userId);
        Task<Supplier> GetSupplier(Guid suppId);
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        Task<Supplier> DeleteSupplier(Guid suppId);
    }
}
