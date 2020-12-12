namespace Trucks.Api.Model.Models
{
    public class TruckCategory
    {
        public int TruckId { get; set; }
        public int CategoryId { get; set; }
        public virtual Truck Truck { get; set; }
        public virtual Category Category { get; set; }
    }
}
