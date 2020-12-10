using System;

namespace Trucks.Api.Model.Models
{
    public class SalesOrderDetail
    {
        public int SalesOrderDetailId { get; set; }
        public int SalesOrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int TruckId { get; set; }
        public Truck Truck { get; set; }
        public SalesOrder SalesOrder { get; set; }
    }
}
