using AutoMapper;
using Trucks.Api.Model.Models;

namespace Trucks.Api.Mapping
{
    public class SalesProfile : Profile
    {
        public SalesProfile()
        {
            CreateMap<SalesOrderDetail, Dto.SalesDto>();
            CreateMap<Dto.SalesDto, SalesOrderDetail>()
                .ForMember(dest => dest.SalesOrder,
                    map => map.MapFrom(
                        source => new SalesOrderHeader
                        {
                            CustomerEmail = source.CustomerEmail,
                            TotalDue = source.TotalDue
                            //SalesDetail = source.

                        }));
            //.ReverseMap();
        }
    }
}
