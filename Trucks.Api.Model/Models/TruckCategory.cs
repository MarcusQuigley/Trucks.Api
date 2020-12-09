namespace Trucks.Api.Model.Models
{
    public class TruckCategory
    {
        public int TruckId { get; set; }
        public int CategoryId { get; set; }
        public Truck Truck { get; set; }
        public Category Category { get; set; }
    }
}
