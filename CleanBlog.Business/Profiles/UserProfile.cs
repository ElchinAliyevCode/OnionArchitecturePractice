using AutoMapper;
using CleanBlog.Business.Dtos.UserDto;
using CleanBlog.Core.Entities;

namespace CleanBlog.Business.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserGetDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
    }
}
