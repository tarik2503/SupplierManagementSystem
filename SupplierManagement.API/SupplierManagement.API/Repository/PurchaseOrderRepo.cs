using Microsoft.EntityFrameworkCore;
using SupplierManagement.API.IRepository;
using SupplierManagement.Data.DBContext;
using SupplierManagement.Data.Models;
using System;

namespace SupplierManagement.API.Repository
{
    public class PurchaseOrderRepo: IPurchaseOrder
    {
        private readonly SupplierManagementDBContext _context;

        public PurchaseOrderRepo(SupplierManagementDBContext _context)
        {
            this._context = _context;
        }

        public async Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            var NewPurchaseOrder = new PurchaseOrder
            {
               PONumber = purchaseOrder.PONumber,
               DeliveryDate = purchaseOrder.DeliveryDate,
               SupplierId = purchaseOrder.SupplierId,
            };

            NewPurchaseOrder.Products = purchaseOrder.Products.Select(d => new ProductList
            {
                Quantity = d.Quantity,
                ProductId = d.ProductId,
                
            }).ToList();

            var result = await _context.PurchaseOrders.AddAsync(NewPurchaseOrder);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders(string userId)
        {
            var purchaseOrders = _context.Suppliers.Where(s => s.UserId == userId)
                                    .SelectMany(s => s.PurchaseOrders);
            return purchaseOrders.ToList();
        }
    }
}
