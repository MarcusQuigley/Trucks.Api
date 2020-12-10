using AutoMapper;
using Trucks.Api.Model.Models;

namespace Trucks.Api.Mapping
{
    public class PhotosProfile : Profile
    {
        public PhotosProfile()
        {
            CreateMap<Photo, Dto.PhotoDto>();
            CreateMap<Dto.PhotoDto, Photo>()
                .ReverseMap();
        }
    }
}
