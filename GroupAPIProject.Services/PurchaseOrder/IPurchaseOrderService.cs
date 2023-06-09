using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupAPIProject.Models.PurchaseOrder;

namespace GroupAPIProject.Services.PurchaseOrder
{
    public interface IPurchaseOrderService
    {
        Task<bool> CreatePurchaseOrderAsync(PurchaseOrderCreate model);
        // Task<bool> UpdatePurchaseOrderAsync(PurchaseOrderUpdate model);
        Task<PurchaseOrderDetail> GetPurchaseOrderByIdAsync(int purchasOrderId);
        Task<PurchaseOrderDetail> DoesPurchaseOrderExistBySupplierIdAsync(int supplierId);
        Task<PurchaseOrderDetail> GetPurchaseOrderByPurchaseOrderItemIdAsync(int purchaseOrderItemId);
    }
}