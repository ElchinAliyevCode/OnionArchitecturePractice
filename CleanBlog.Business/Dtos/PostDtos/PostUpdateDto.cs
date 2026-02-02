using Microsoft.AspNetCore.Http;

namespace CleanBlog.Business.Dtos.PostDtos;

public class PostUpdateDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public IFormFile? Image { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public int UserId { get; set; }
}
