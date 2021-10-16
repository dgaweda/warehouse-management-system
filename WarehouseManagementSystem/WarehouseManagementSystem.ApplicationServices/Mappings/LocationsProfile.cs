using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .ForMember(x => x.MaxAmount, y => y.MapFrom(z => z.MaxAmount));
        }
    }
}
