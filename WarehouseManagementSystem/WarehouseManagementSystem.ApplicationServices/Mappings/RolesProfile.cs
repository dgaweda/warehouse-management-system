using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Role, API.Domain.Models.Role>().ReverseMap();
        }
        
    }
}
