using System.Collections.Generic;

namespace Trucks.Api.Model.Models
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PreviousPrice { get; set; }
        public int Quantity { get; set; }
        public bool Hidden { get; set; }
        public bool Damaged { get; set; }
        public string DefaultPhotoPath { get; set; }


        public virtual ICollection<Photo> Photos { get; set; }
        //   = new List<Photo>();
        public virtual ICollection<TruckCategory> TruckCategories { get; set; }
        //= new List<TruckCategory>();
        public virtual ICollection<SalesOrderDetail> Sales { get; set; }
         = new List<SalesOrderDetail>();

    }
}
