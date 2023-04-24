using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAPIProject.Models.InventoryItem
{
    public class InventoryItemDelete
    {
        public int InventoryItemId { get; set; }
        public int PurchaseOrderId { get; set; }

    }
}
