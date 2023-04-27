using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAPIProject.Models.PurchaseOrderItem
{
    public class PurchaseOrderItemListItem
    {
          public int Id{get;set;}
        public int PurchaseOrderId{get;set;}
        public string ProductName{get;set;}
        public int Quantity{get;set;}
    }
}