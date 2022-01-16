using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Role, API.Domain.Models.Role>();

            CreateMap<EditRoleRequest, Role>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Salary, opt => opt.MapFrom(src => src.Salary));

            CreateMap<AddRoleRequest, Role>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Salary, opt => opt.MapFrom(src => src.Salary));

            CreateMap<RemoveRoleRequest, Role>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.RoleId));
        }
        
    }
}
