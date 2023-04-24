using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GroupAPIProject.Data;
using GroupAPIProject.Data.Entities;
using GroupAPIProject.Models.PurchaseOrderItem;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GroupAPIProject.Services.PurchaseOrderItem
{
    public class PurchaseOrderItemService : IPurchaseOrderItemService
    {
        private readonly int _retailerId;
        private readonly ApplicationDbContext _dbContext;
        public PurchaseOrderItemService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _retailerId);
            if (!validId)
                throw new Exception("Attempted to build  without Retailer Id claim.");


            _dbContext = dbContext;
        }

        public async Task<bool> CreatePurchaseOrderItemAsync(PurchaseOrderItemCreate model)
        {

            PurchaseOrderEntity purchaseOrderExists = await _dbContext.PurchaseOrders.Where(entity => entity.RetailerId == _retailerId).FirstOrDefaultAsync(g => g.Id == model.PurchaseOrderId);
            if (purchaseOrderExists is null)
            {
                return false;
            }
            // checks if the product exists in the PurchaseOrder's Supplier's list of products
            ProductEntity productExists = await _dbContext.Suppliers.Where(g => g.Id == purchaseOrderExists.SupplierId)
                .Include(g => g.ListOfProducts).SelectMany(g => g.ListOfProducts).FirstOrDefaultAsync(g => g.Id == model.ProductId);
            if (productExists is null)
            {
                return false;
            }

            PurchaseOrderItemEntity entity = new PurchaseOrderItemEntity
            {
                PurchaseOrderId = model.PurchaseOrderId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                Price = model.Price
            };
            _dbContext.PurchaseOrderItems.Add(entity);
            int numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;

            // RetailerEntity retailerExists = await _dbContext.Users.OfType<RetailerEntity>().FirstOrDefaultAsync(g => g.Id == model.RetailerId);
            // if (retailerExists is null)
            // {
            //     return false;
            // }
            // // SupplierEntity supplierExists = await _dbContext.Suppliers.FirstOrDefaultAsync(g => g.Id == model.SupplierId);
            // ProductEntity productExists = await _dbContext.Products.FindAsync(model.ProductId);

            // if (productExists is null)
            // {
            //     return false;
            // }
            // // check if supplier contains product 
            // SupplierEntity supplierExists = await _dbContext.Suppliers.FindAsync(productExists.SupplierId);
            // if(supplierExists is null){
            //     return false;
            // }
            // PurchaseOrderEntity purchaseOrderExists = await _dbContext.PurchaseOrders.FindAsync(model.PurchaseOrderId);

            // if (purchaseOrderExists is null || purchaseOrderExists.RetailerId != _retailerId)
            // {
            //     return false;
            // }

            // PurchaseOrderItemEntity entity = new PurchaseOrderItemEntity
            // {
            //     RetailerId = _retailerId,
            //     ProductId = model.ProductId,
            //     PurchaseOrderId = model.PurchaseOrderId,
            //     Quantity = model.Quantity,
            //     Price = productExists.Price
            // };
            // // aftr creating a PurchaseOrderItemEntity, need to later add to an existing InventoryItem


            // _dbContext.PurchaseOrderItems.Add(entity);
            // int numberOfChanges = await _dbContext.SaveChangesAsync();
            // return numberOfChanges == 1;

        }
        // public async Task<bool> UpdatePurchaseOrderItemAsync(PurchaseOrderItemUpdate model)
        // {
        //     // if already sold something to customer, we cannot update purchase order item
        //     if()

        //     PurchaseOrderItemEntity purchaseOrderItemExists = await _dbContext.PurchaseOrderItems.FindAsync(model.Id);
        //     if (purchaseOrderItemExists is null || purchaseOrderItemExists.RetailerId != _retailerId)
        //     {
        //         return false;
        //     }
        //     int originalQuantity = purchaseOrderItemExists.Quantity;
        //     purchaseOrderItemExists.Quantity = model.Quantity;
        //     //need to find associated inventoryItem to update if not we just update the purchaseOrderItem
        //     PurchaseOrderEntity purchaseOrderExists = await _dbContext.PurchaseOrders.FindAsync(purchaseOrderItemExists.PurchaseOrderId);
        //     if (purchaseOrderExists is null || purchaseOrderExists.RetailerId != _retailerId)
        //     {
        //         return false;
        //     }

        //     InventoryItemEntity inventoryItemExists = await _dbContext.InventoryItems.FindAsync(purchaseOrderExists.Id);
        //     if (inventoryItemExists is null || inventoryItemExists.RetailerId != _retailerId)
        //     {
        //         return false;
        //     }

        //     if (model.Quantity < originalQuantity)
        //     {
        //         inventoryItemExists.Stock = inventoryItemExists.Stock + (originalQuantity - model.Quantity);
        //         LocationEntity locationCapacityUpdate = await _dbContext.Locations.FindAsync(inventoryItemExists.LocationId);
        //         locationCapacityUpdate.Capacity = locationCapacityUpdate.Capacity + (originalQuantity - model.Quantity);
        //         int counter = await _dbContext.SaveChangesAsync();
        //         return counter == 3;
        //     }
        //     else if (model.Quantity > originalQuantity)
        //     {
        //         inventoryItemExists.Stock = inventoryItemExists.Stock - (model.Quantity - originalQuantity);
        //         LocationEntity locationCapacityUpdate = await _dbContext.Locations.FindAsync(inventoryItemExists.LocationId);
        //         locationCapacityUpdate.Capacity = locationCapacityUpdate.Capacity - (model.Quantity - originalQuantity);
        //         int counter = await _dbContext.SaveChangesAsync();
        //         return counter == 3;
        //     }



        //     int numberOfChanges = await _dbContext.SaveChangesAsync();
        //     return numberOfChanges == 1;
        // }
        public async Task<PurchaseOrderItemDetail> GetPurchaseOrderItemByIdAsync(int purchaseOrderItemId)
        {
            PurchaseOrderItemEntity purchaseOrderItemExists = await _dbContext.PurchaseOrders.Where(entity => entity.RetailerId == _retailerId)
                .Include(g => g.ListOfPurchaseOrderItems).SelectMany(g => g.ListOfPurchaseOrderItems).FirstOrDefaultAsync(g => g.Id == purchaseOrderItemId);
            if (purchaseOrderItemExists is null)
            {
                return null;
            }
            PurchaseOrderItemDetail detail = new PurchaseOrderItemDetail{
                Id = purchaseOrderItemExists.Id,
                PurchaseOrderId = purchaseOrderItemExists.PurchaseOrderId,
                ProductId = purchaseOrderItemId,
                Quantiy = purchaseOrderItemExists.Quantity,
                Price = purchaseOrderItemExists.Price

            };
            return detail;

        }




    }
}