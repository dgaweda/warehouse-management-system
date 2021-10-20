using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<AddEmployeeRequest, Employee>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId));
            var cfg = new MapperConfiguration(cfg =>
            CreateMap<(List<Employee> employee, GetEmployeesByRoleRequest request), API.Domain.Models.Employee>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.employee.Select(x => x.Name)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.employee.Select(x => x.LastName)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.employee.Select(x => x.Id)))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.request.RoleName)));

            cfg.AssertConfigurationIsValid();



        }
    }
}
