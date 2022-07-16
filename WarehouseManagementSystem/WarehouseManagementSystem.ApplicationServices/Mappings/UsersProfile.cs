using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;

namespace WarehouseManagementSystem.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<AddUserRequest, User>();

            CreateMap<User, API.Domain.Models.UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.RoleId));

            CreateMap<EditUserRequest, User>();

            CreateMap<RemoveUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
