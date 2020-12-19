using System.Collections.Generic;

namespace Trucks.Api.Model.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsMini { get; set; }
        public int Order { get; set; }
        public virtual ICollection<TruckCategory> TruckCategories { get; set; }
    }
}
