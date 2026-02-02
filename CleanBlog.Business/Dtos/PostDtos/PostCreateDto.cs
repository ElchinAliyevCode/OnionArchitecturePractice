using Microsoft.AspNetCore.Http;

namespace CleanBlog.Business.Dtos.PostDtos;

public class PostCreateDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public IFormFile Image { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
}
