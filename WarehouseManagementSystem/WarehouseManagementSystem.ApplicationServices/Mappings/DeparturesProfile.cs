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
                .ForMember(dest => dest.OpeningTime, opt => opt.MapFrom(src => src.OpeningTime))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.CloseTime, opt => opt.MapFrom(src => src.CloseTime));
        }
    }
}
