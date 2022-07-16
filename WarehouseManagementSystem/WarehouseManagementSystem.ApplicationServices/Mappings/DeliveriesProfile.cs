using AutoMapper;
using DataAccess.CQRS.Query.Queries.DeliveryQueries;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class DeliveriesProfile : Profile
    {
        public DeliveriesProfile()
        {
            CreateMap<Delivery, DeliveryDto>()
                .ForMember(dest => dest.Arrival, option => option.MapFrom(src => src.Arrival))
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Name));

            CreateMap<AddDeliveryRequest, Delivery>()
                .ForMember(dest => dest.Arrival, option => option.MapFrom(src => src.Arrival));

            CreateMap<RemoveDeliveryRequest, Delivery>()
                .ForMember(dest => dest.Id, option => option.MapFrom(src => src.Id));

            CreateMap<EditDeliveryRequest, Delivery>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Arrival, opt => opt.MapFrom(src => src.Arrival));
            
            // CreateMap<GetDeliveriesRequest, GetDeliveriesQuery>()
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
