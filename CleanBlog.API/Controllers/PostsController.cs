using CleanBlog.Business.Dtos.PostDtos;
using CleanBlog.Business.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanBlog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostService _service;

    public PostsController(IPostService service)
    {
        _service = service;
    }

    [HttpGet("get-all-posts")]
    public async Task<ActionResult> GetAll()
    {
        var posts = await _service.GetAllAsync();
        return Ok(posts);
    }

    [HttpPost("create-post")]
    public async Task<IActionResult> Create([FromForm] PostCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut("update-post")]
    public async Task<IActionResult> Update([FromForm] PostUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var post = await _service.GetAsync(id);
        return Ok(post);
    }
}
