using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class SenioritiesProfile : Profile
    {
        public SenioritiesProfile()
        {
            CreateMap<Seniority, API.Domain.Models.Seniority>()
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.EmploymentDate, y => y.MapFrom(z => z.EmploymentDate))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.User.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.User.LastName))
                .ForMember(dest => dest.EmploymentDuration, opt => opt.MapFrom(src =>
                    string.Format("{0} Year/s {1} Month/s)", (DateTime.Now - src.EmploymentDate).Days / 365, ((DateTime.Now - src.EmploymentDate).Days % 365) / 30)));

            CreateMap<AddSeniorityRequest, Seniority>()
                .ForMember(x => x.EmploymentDate, y => y.MapFrom(z => z.EmploymentDate))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

            CreateMap<EditSeniorityRequest, Seniority>()
                .ForMember(x => x.EmploymentDate, opt => opt.MapFrom(src => src.EmploymentDate))
                .ForMember(x => x.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
