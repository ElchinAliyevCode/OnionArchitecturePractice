using CleanBlog.Business.Dtos.UserDto;
using CleanBlog.Business.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanBlog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllAsync();
        return Ok(users);
    }

    [HttpPost("create-user")]
    public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok("User created successfully");
    }

    [HttpPut("update-post")]
    public async Task<IActionResult> Update([FromBody] UserUpdateDto dto)
    {
        await _service.UpdateAsync(dto);
        return Ok("User updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _service.DeleteAsync(id);
        return Ok("User deleted successfully");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _service.GetAsync(id);
        return Ok(user);
    }
}
