using Microsoft.EntityFrameworkCore;
using SupplierManagement.API.IRepository;
using SupplierManagement.Data.DBContext;
using SupplierManagement.Data.Models;

namespace SupplierManagement.API.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly SupplierManagementDBContext _context;

        public ProductRepo(SupplierManagementDBContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Product>> GetProducts(string userId)
        {

            var products = _context.Suppliers.Where(s => s.UserId == userId )
                                    .SelectMany(s => s.Products).Where(p => !p.IsDeleted);
            return products.ToList();

        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierId(string userId, Guid supplierId)
        {

            var products = _context.Suppliers.Where(s => s.UserId == userId)
                                    .SelectMany(s => s.Products).Where(p => !p.IsDeleted && p.SupplierId == supplierId);
            return products.ToList();

        }

        public async Task<Product> GetProductBySKU(string SKU)
        {
            return await _context.Products
               .FirstOrDefaultAsync(e => e.ProductSKU == SKU);
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            return await _context.Products
               .FirstOrDefaultAsync(e => e.Id == productId);
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _context.Products
                .FirstOrDefaultAsync(e => e.Id == product.Id);

            if (result != null)
            {
                result.Title = product.Title;
               result.ImagePath = product.ImagePath;
                result.ProductSKU = product.ProductSKU;
                result.CostPrice = product.CostPrice;
                result.SellingPrice = product.SellingPrice;
                result.SupplierId = product.SupplierId;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Product> DeleteProduct(Guid productId)
        {
            var result = await _context.Products
                .FirstOrDefaultAsync(e => e.Id == productId);
            if (result != null)
            {
                result.IsDeleted = true;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
