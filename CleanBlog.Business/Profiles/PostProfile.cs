using AutoMapper;
using CleanBlog.Business.Dtos.PostDtos;
using CleanBlog.Core.Entities;

namespace CleanBlog.Business.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, PostGetDto>().ReverseMap();
        CreateMap<Post, PostCreateDto>().ReverseMap();
        CreateMap<Post, PostUpdateDto>().ReverseMap();
    }
}
