using CleanBlog.Business.Dtos.ResultDtos;
using CleanBlog.Business.Dtos.UserDto;

namespace CleanBlog.Business.Services.Abstractions;

public interface IUserService
{
    Task<ResultDto> CreateAsync(UserCreateDto dto);
    Task<ResultDto> DeleteAsync(int id);
    Task<ResultDto> UpdateAsync(UserUpdateDto dto);
    Task<ResultDto<List<UserGetDto>>> GetAllAsync();
    Task<ResultDto<UserGetDto>> GetAsync(int id);
}
