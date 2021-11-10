using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class SenioritiesProfile : Profile
    {
        public SenioritiesProfile()
        {
            CreateMap<Seniority, API.Domain.Models.Seniority>()
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId))
                .ForMember(x => x.EmploymentDate, y => y.MapFrom(z => z.EmploymentDate))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Employee.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.Employee.LastName))
                .ForMember(dest => dest.EmploymentDuration, opt => opt.MapFrom(src =>
                    string.Format("{0} Year/s {1} Month/s)", (DateTime.Now - src.EmploymentDate).Days / 365, ((DateTime.Now - src.EmploymentDate).Days % 365) / 30)));


        }
    }
}
