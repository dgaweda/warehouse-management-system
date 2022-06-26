using AutoMapper;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;

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

            CreateMap<User, API.Domain.Models.UserDTO>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.RoleId));

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
