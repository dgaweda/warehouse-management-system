using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class DeliveriesProfile : Profile
    {
        public DeliveriesProfile()
        {
            CreateMap<Delivery, API.Domain.Models.Delivery>()
                .ForMember(dest => dest.Arrival, option => option.MapFrom(src => src.Arrival))
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Name));

            CreateMap<AddDeliveryRequest, Delivery>()
                .ForMember(dest => dest.Arrival, option => option.MapFrom(src => src.Arrival));

            CreateMap<RemoveDeliveryRequest, Delivery>()
                .ForMember(dest => dest.Id, option => option.MapFrom(src => src.DeliveryId));

            CreateMap<EditDeliveryRequest, Delivery>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Arrival, opt => opt.MapFrom(src => src.Arrival));
        }
    }
}
