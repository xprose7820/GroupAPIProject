using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupAPIProject.Models.SalesOrder;

namespace GroupAPIProject.Services.SalesOrder
{
    public interface ISalesOrderService
    {
        public Task<bool> CreateSalesOrderAsync(SalesOrderCreate model);
        // public Task<bool> UpdateSalesOrderAsync(SalesOrderUpdate model);
        public Task<SalesOrderDetail> GetSalesOrderByIdAsync(int salesOrderId);
          public Task<SalesOrderDetail> DoesSalesOrderExistByCustomerId(int customerId);
    }
}