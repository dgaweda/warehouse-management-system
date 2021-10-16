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
                .ForMember(x => x.EmploymentDate, y => y.MapFrom(z => z.EmploymentDate));
        }
    }
}
