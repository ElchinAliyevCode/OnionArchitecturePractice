using CleanBlog.Business.Dtos.PostDtos;
using CleanBlog.Business.Dtos.ResultDtos;

namespace CleanBlog.Business.Services.Abstractions;

public interface IPostService
{
    Task<ResultDto> CreateAsync(PostCreateDto dto);
    Task<ResultDto> UpdateAsync(PostUpdateDto dto);
    Task<ResultDto> DeleteAsync(int id);
    Task<ResultDto<List<PostGetDto>>> GetAllAsync();
    Task<ResultDto<PostGetDto>> GetAsync(int id);
}
