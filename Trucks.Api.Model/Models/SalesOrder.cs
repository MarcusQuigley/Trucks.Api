using System;

namespace Trucks.Api.Model.Models
{
    public class SalesOrder
    {
        public int SalesOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerDetailsId { get; set; }
        public Decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int SalesOrderDetailId { get; set; }
        public SalesOrderDetail SalesDetail { get; set; }
    }
}
