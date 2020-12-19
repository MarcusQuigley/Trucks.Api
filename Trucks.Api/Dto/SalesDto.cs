using System;

namespace Trucks.Api.Dto
{
    public class SalesDto
    {
        public int SalesOrderDetailId { get; set; }
        public int SalesOrderId { get; set; }
        public int Quantity { get; set; }
        // public DateTime ModifiedDate { get; set; }
        public int TruckId { get; set; }
        // public TruckDto Truck { get; set; }
        //  public SalesOrder SalesOrder { get; set; }

        //  public DateTime OrderDate { get; set; }

        public string CustomerEmail { get; set; }
        public Decimal TotalDue { get; set; }
    }
}
