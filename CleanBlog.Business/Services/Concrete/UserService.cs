using AutoMapper;
using CleanBlog.Business.Dtos.ResultDtos;
using CleanBlog.Business.Dtos.UserDto;
using CleanBlog.Business.Exceptions;
using CleanBlog.Business.Services.Abstractions;
using CleanBlog.Core.Entities;
using CleanBlog.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanBlog.Business.Services.Concrete;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResultDto> CreateAsync(UserCreateDto dto)
    {
        var user = _mapper.Map<User>(dto);
        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        return new("Created");
    }

    public async Task<ResultDto> DeleteAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null)
        {
            throw new NotFoundException("User is not found");
        }

        _repository.Delete(user);
        await _repository.SaveChangesAsync();

        return new("Deleted");
    }

    public async Task<ResultDto<List<UserGetDto>>> GetAllAsync()
    {
        var users = await _repository.GetAll().ToListAsync();
        var dto = _mapper.Map<List<UserGetDto>>(users);
        return new(dto);
    }

    public async Task<ResultDto<UserGetDto>> GetAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null)
        {
            throw new NotFoundException("User is not found");
        }

        var dto = _mapper.Map<UserGetDto>(user);
        return new(dto);
    }

    public async Task<ResultDto> UpdateAsync(UserUpdateDto dto)
    {
        var user = await _repository.GetByIdAsync(dto.Id);
        if (user == null)
        {
            throw new NotFoundException("User is not found");
        }

        user = _mapper.Map(dto, user);
        _repository.Update(user);
        await _repository.SaveChangesAsync();

        return new("Updated");
    }
}
