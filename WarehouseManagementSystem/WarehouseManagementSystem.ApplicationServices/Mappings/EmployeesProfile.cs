﻿using AutoMapper;
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
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.PESEL, opt => opt.MapFrom(src => src.PESEL))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));

            CreateMap<Employee, API.Domain.Models.Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.EmploymentDuration, opt => opt.MapFrom(src =>
                    string.Format("{0} Year/s {1} Month/s)", (DateTime.Now - src.Seniority.EmploymentDate).Days / 365, ((DateTime.Now - src.Seniority.EmploymentDate).Days % 365) / 30)));

            CreateMap<EditEmployeeRequest, Employee>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.PESEL, opt => opt.MapFrom(src => src.PESEL))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));

            CreateMap<RemoveEmployeeRequest, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeId));
        }
    }
}
