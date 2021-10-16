using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class DeparturesProfile : Profile
    {
        public DeparturesProfile()
        {
            CreateMap<Departure, API.Domain.Models.Departure>()
                .ForMember(x => x.DepartureTime, y => y.MapFrom(z => z.DepartureTime));
        }
    }
}
