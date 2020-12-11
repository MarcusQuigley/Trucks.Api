﻿using System;

namespace Trucks.Api.Model.Models
{
    public class TruckInventory
    {
        public int TruckInventoryId { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedDate { get; set; }
        //   public int TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}
