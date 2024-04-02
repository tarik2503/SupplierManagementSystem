using SupplierManagement.Data.Models;

namespace SupplierManagement.API.IRepository
{
    public interface IPurchaseOrder
    {
        Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder purchaseOrder);

        Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders(string UserId);
    }
}
