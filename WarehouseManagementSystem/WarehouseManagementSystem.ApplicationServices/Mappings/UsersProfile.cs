using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Routing.Constraints;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<AddUserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src  => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom( src => src.Email))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.UserName))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.PESEL, opt => opt.MapFrom(src => src.PESEL))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));

            CreateMap<User, API.Domain.Models.User>()
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (RoleEnum.Roles) src.RoleId));

            CreateMap<EditUserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.UserName))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.PESEL, opt => opt.MapFrom(src => src.PESEL))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));

            CreateMap<RemoveUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
