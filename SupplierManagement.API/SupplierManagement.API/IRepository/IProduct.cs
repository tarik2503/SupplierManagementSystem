using SupplierManagement.Data.Models;

namespace SupplierManagement.API.IRepository
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts(string userId);
        Task<IEnumerable<Product>> GetProductsBySupplierId(string userId, Guid supplierId);
        Task<Product> GetProduct(Guid productId);
        Task<Product> GetProductBySKU(string SKU);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(Guid productId);
    }
}
