using AutoMapper;
using planning.Entities.DTOs;
using planning.Entities.Entities;
using planning.Entities.Wrappers;

namespace planning.WebApplication.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<User, UserWrapper>();
        CreateMap<UserDto, User>();
        CreateMap<Group, GroupWrapper>();
        CreateMap<GroupDto, Group>();
    }
}