using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAPIProject.Models.SalesOrderItem
{
    public class SalesOrderItemDetail
    {
        public int Id;
        public int SalesOrderId;
        public string ProductName;
        public int Quantity;
        public double Price;

    }
}