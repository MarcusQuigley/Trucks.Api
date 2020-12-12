using System;
using System.Collections.Generic;

namespace Trucks.Api.Dto
{
    public class TruckDto
    {
        public int TruckId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Decimal Price { get; set; }
        public Decimal PreviousPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string DefaultPhotoPath { get; set; }

        //public ICollection<TruckCategoryDto> Categories { get; set; }
        //   = new List<TruckCategoryDto>();
        public ICollection<CategoryDto> Categories { get; set; }
         = new List<CategoryDto>();

        public ICollection<PhotoDto> Photos { get; set; }
            = new List<PhotoDto>();
    }
}
