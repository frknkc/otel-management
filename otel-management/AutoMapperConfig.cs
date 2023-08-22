using AutoMapper;
using otel_management.Entities;
using otel_management.Models;

namespace otel_management
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, EditUserModel>().ReverseMap();
            CreateMap<Room, RoomViewModel>().ReverseMap();
            CreateMap<Service, ServiceViewModel>().ReverseMap();


        }
    }
}
