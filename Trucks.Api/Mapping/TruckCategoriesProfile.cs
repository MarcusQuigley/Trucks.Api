using AutoMapper;
using Trucks.Api.Model.Models;

namespace Trucks.Api.Mapping
{
    public class TruckCategoryProfile : Profile
    {
        public TruckCategoryProfile()
        {
            CreateMap<TruckCategory, Dto.TruckCategoryDto>();
            CreateMap<Dto.TruckCategoryDto, TruckCategory>()
                .ReverseMap();
        }
    }
}
