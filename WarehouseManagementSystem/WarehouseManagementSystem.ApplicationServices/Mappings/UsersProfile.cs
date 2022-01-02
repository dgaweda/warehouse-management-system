using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, API.Domain.Models.User>()
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.Employee.LastName))
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.UserName))
                .ForMember(dest => dest.RoleName, options => options.MapFrom(src => src.Employee.Role.Name));
        }
    }
}
