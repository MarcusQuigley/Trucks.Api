using System;

namespace Trucks.Api.Dto
{
    public class TruckInventoryDto
    {
        public int TruckInventoryId { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedDate { get; set; }
        // public int TruckId { get; set; }
        public TruckDto Truck { get; set; }
    }
}
