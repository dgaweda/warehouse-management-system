using AutoMapper;
using DataAccess.Entities;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class SeniorityProfile : Profile
    {
        public SeniorityProfile()
        {
            CreateMap<Seniority, SeniorityDto>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.User.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.User.LastName))
                .ForMember(dest => dest.EmploymentDuration, opt => opt.MapFrom(src =>
                    string.Format("{0} Year/s {1} Month/s)", (DateTime.Now - src.EmploymentDate).Days / 365, ((DateTime.Now - src.EmploymentDate).Days % 365) / 30)));

            CreateMap<AddSeniorityRequest, Seniority>();

            CreateMap<EditSeniorityRequest, Seniority>();
        }
    }
}
