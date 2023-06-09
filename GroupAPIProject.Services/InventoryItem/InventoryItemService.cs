﻿using GroupAPIProject.Data;
using GroupAPIProject.Data.Entities;
using GroupAPIProject.Models.InventoryItem;
using GroupAPIProject.Models.Location;
using GroupAPIProject.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace GroupAPIProject.Services.InventoryItem
{
    public class InventoryItemService : IInventoryItemService
    {
        private readonly int _retailerId;
        private readonly ApplicationDbContext _dbContext;

        public InventoryItemService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            ClaimsIdentity? userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            string value = userClaims.FindFirst("Id")?.Value;
            bool validId = int.TryParse(value, out _retailerId);
            if (!validId)
            {
                throw new Exception("Attempted to build without Retailer Id Claim");
            }
            _dbContext = dbContext;
        }
        public async Task<bool> CreateInventoryItemAsync(InventoryItemCreate model)
        {
            PurchaseOrderItemEntity purchaseOrderItemExists = await _dbContext.PurchaseOrders.Where(entity => entity.RetailerId == _retailerId).Where(p => p.Id == model.PurchaseOrderId)
                .Include(g => g.ListOfPurchaseOrderItems).SelectMany(g => g.ListOfPurchaseOrderItems).FirstOrDefaultAsync(g => g.Id == model.PurchaseOrderItemId);

            if (purchaseOrderItemExists is null)
            {
                return false;
            }
            if (purchaseOrderItemExists.Quantity == 0)
            {
                return false;
            }
            LocationEntity locationExists = await _dbContext.Locations.Where(entity => entity.RetailerId == _retailerId).FirstOrDefaultAsync(g => g.Id == model.LocationId);
            if (locationExists is null || locationExists.Capacity < purchaseOrderItemExists.Quantity)
            {
                return false;
            }
            PurchaseOrderEntity purchaseOrderExists = await _dbContext.PurchaseOrders.Where(entity => entity.RetailerId == _retailerId).FirstOrDefaultAsync(g => g.Id == model.PurchaseOrderId);
            if (purchaseOrderExists is null)
            {
                return false;
            }
            ProductEntity productExists = await _dbContext.Suppliers.Where(entity => entity.Id == purchaseOrderExists.SupplierId)
                .Include(g => g.ListOfProducts).SelectMany(g => g.ListOfProducts).FirstOrDefaultAsync(g => g.Id == purchaseOrderItemExists.ProductId);
            if (productExists is null)
            {
                return false;
            }

            InventoryItemEntity entity = new InventoryItemEntity
            {
                ProductName = productExists.ProductName,
                LocationId = model.LocationId,
                PurchaseOrderId = model.PurchaseOrderId,
                Stock = purchaseOrderItemExists.Quantity
            };
            locationExists.Capacity = locationExists.Capacity - purchaseOrderItemExists.Quantity;

            purchaseOrderItemExists.Quantity = 0;

            _dbContext.InventoryItems.Add(entity);
            int numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 3;
        }
        public async Task<bool> UpdateInventoryItemAsync(InventoryItemUpdate model)
        {


            LocationEntity locationExists = await _dbContext.Locations.Where(entity => entity.RetailerId == _retailerId).FirstOrDefaultAsync(g => g.Id == model.LocationId);
            if (locationExists == null)
            {
                return false;
            }
            InventoryItemEntity inventoryItemExists = await _dbContext.InventoryItems.FindAsync(model.Id);
            if (inventoryItemExists == null)
            {
                return false;
            }
            else
            {
                inventoryItemExists.LocationId = model.LocationId;
            }

            int numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<bool> DeleteInventoryItemByIdAsync(InventoryItemDelete model)
        {
            InventoryItemEntity inventoryItemExists = await _dbContext.InventoryItems.FindAsync(model.InventoryItemId);
            if (inventoryItemExists == null) 
            {
                return false;
            }
          
            _dbContext.InventoryItems.Remove(inventoryItemExists);
            int numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<InventoryItemDetail> GetInventoryItemByIdAsync(int inventoryItemId)
        {
            InventoryItemEntity inventoryItemExists = await _dbContext.InventoryItems.FindAsync(inventoryItemId);
            if (inventoryItemExists == null)
            {
                return null;
            }
            InventoryItemDetail inventoryItemDetail = new InventoryItemDetail
            {
                InventoryItemId = inventoryItemExists.Id,
                PurchaseOrderId = inventoryItemExists.PurchaseOrderId,
                LocationId = inventoryItemExists.LocationId,
                Stock = inventoryItemExists.Stock,
            };
            return inventoryItemDetail;
        }
        //public async Task<IEnumerable<InventoryItemDetail>> GetInventoryItemListByLocationIdAsync(int locationId)
        //{
        //    LocationEntity locationExists = await _dbContext.Locations.Where(entity => entity.RetailerId == _retailerId)
        //        .FirstOrDefaultAsync(g => g.Id == locationId);
        //    var inventoryItemToDisplay = await _dbContext.InventoryItems.Where(g => g.LocationId == locationId)
        //        .Select(entity => new InventoryItemDetail
        //        {
        //            InventoryItemId = entity.Id,
        //            PurchaseOrderId = entity.PurchaseOrderId,
        //            LocationId = entity.LocationId,
        //            Stock = entity.Stock,
        //        }).ToListAsync();
        //
        //    return inventoryItemToDisplay;
        //}


    }
}
