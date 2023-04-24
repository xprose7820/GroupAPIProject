using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupAPIProject.Models.SalesOrder
{
    public class SalesOrderDetail
    {
        public int Id;
        public int CusomterId;
        
        public int LocationId;
        public DateTimeOffset OrderDate;
    }
}