﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Trucks.Api.Model.Models
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PreviousPrice { get; set; }

        [ForeignKey("Category")]
        public int TruckInventoryId { get; set; }
        public TruckInventory TruckInventory { get; set; }

    }
}