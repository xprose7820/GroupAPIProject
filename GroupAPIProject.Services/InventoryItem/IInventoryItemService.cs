using GroupAPIProject.Models.InventoryItem;
using GroupAPIProject.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAPIProject.Services.InventoryItem
{
    public interface IInventoryItemService
    {
        Task<bool> CreateInventoryItemAsync(InventoryItemCreate model);
        Task<InventoryItemDetail> GetInventoryItemByIdAsync(int inventoryItemId);
       // Task<IEnumerable<InventoryItemDetail>> GetInventoryItemListByLocationIdAsync(int locationId);
        Task<bool> UpdateInventoryItemAsync(InventoryItemUpdate model);
        Task<bool> DeleteInventoryItemByIdAsync(InventoryItemDelete model);
    }
}
