using AutoMapper;
using CleanBlog.Business.Dtos.PostDtos;
using CleanBlog.Business.Dtos.ResultDtos;
using CleanBlog.Business.Exceptions;
using CleanBlog.Business.Services.Abstractions;
using CleanBlog.Core.Entities;
using CleanBlog.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanBlog.Business.Services.Concrete;

public class PostService : IPostService
{
    private readonly IPostRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloud;
    public PostService(IPostRepository repository, IMapper mapper, ICloudinaryService cloud)
    {
        _repository = repository;
        _mapper = mapper;
        _cloud = cloud;
    }

    public async Task<ResultDto> CreateAsync(PostCreateDto dto)
    {
        var post = _mapper.Map<Post>(dto);

        var imagePath = await _cloud.FileUploadAsync(dto.Image);
        post.ImagePath = imagePath;

        await _repository.AddAsync(post);
        await _repository.SaveChangesAsync();

        return new("Created");
    }

    public async Task<ResultDto> DeleteAsync(int id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post == null)
        {
            throw new NotFoundException("Post not found");
        }

        _repository.Delete(post);
        await _repository.SaveChangesAsync();

        await _cloud.FileDeleteAsync(post.ImagePath);

        return new("Deleted");
    }

    public async Task<ResultDto<List<PostGetDto>>> GetAllAsync()
    {
        var posts = await _repository.GetAll().Include(x => x.User).ToListAsync();
        var dto = _mapper.Map<List<PostGetDto>>(posts);
        return new(dto);
    }

    public async Task<ResultDto<PostGetDto>> GetAsync(int id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post == null)
        {
            throw new NotFoundException("Post not found");
        }

        var dto = _mapper.Map<PostGetDto>(post);
        return new(dto);
    }

    public async Task<ResultDto> UpdateAsync(PostUpdateDto dto)
    {
        var post = await _repository.GetByIdAsync(dto.Id);
        if (post == null)
        {
            throw new NotFoundException("Post not found");
        }

        post = _mapper.Map(dto, post);

        if (dto.Image is { })
        {
            await _cloud.FileDeleteAsync(post.ImagePath);
            var imagePath = await _cloud.FileUploadAsync(dto.Image);
            post.ImagePath = imagePath;
        }

        _repository.Update(post);
        await _repository.SaveChangesAsync();

        return new("Updated");
    }
}
