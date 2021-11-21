using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class LocationsProfile : Profile
    {
        public LocationsProfile()
        {
            CreateMap<Location, API.Domain.Models.Location>()
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.CurrentAmount, y => y.MapFrom(z => z.CurrentAmount))
                .ForMember(x => x.MaxAmount, y => y.MapFrom(z => z.MaxAmount))
                .ForMember(x => x.ProductName, y => y.MapFrom(src => src.Product.Name));

            CreateMap<AddLocationRequest, Location>()
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.LocationType))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.MaxAmount, y => y.MapFrom(z => z.MaxAmount));

            CreateMap<RemoveLocationRequest, Location>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            CreateMap<EditLocationRequest, Location>()
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.MaxAmount, y => y.MapFrom(z => z.MaxAmount));

            CreateMap<EditLocationCurrentAmountRequest, Location>()
                .ForMember(x => x.CurrentAmount, y => y.MapFrom(z => z.CurrentAmount));

        }
    }
}
