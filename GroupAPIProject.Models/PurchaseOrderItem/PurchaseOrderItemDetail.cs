using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAPIProject.Models.PurchaseOrderItem
{
    public class PurchaseOrderItemDetail
    {
        public int Id;
        public int PurchaseOrderId;
        public int ProductId;
        public int Quantiy; 
        public double Price;
    }
}