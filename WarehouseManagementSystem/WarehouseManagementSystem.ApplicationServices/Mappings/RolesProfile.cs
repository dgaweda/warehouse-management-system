using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Role, RoleDto>();

            CreateMap<EditRoleRequest, Role>();

            CreateMap<AddRoleRequest, Role>();

            CreateMap<RemoveRoleRequest, Role>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));
        }
        
    }
}
