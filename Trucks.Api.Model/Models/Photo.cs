﻿namespace Trucks.Api.Model.Models
{
    public class Photo  //book
    {
        public int PhotoId { get; set; }
        public string PhotoPath { get; set; }

        public int TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}
