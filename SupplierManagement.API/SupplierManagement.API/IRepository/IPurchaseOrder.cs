using SupplierManagement.Data.Models;

namespace SupplierManagement.API.IRepository
{
    public interface IPurchaseOrder
    {
        Task<bool> AddPurchaseOrder(PurchaseOrder purchaseOrder);

        Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders(string UserId);
        Task<PurchaseOrder> GetPurchaseOrder(Guid purchaseOrderId);

        Task<bool> UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
        Task<bool> DeletePurchaseOrder(Guid purchaseOrderId);
    }
}
