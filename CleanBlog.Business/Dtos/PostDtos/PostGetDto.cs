namespace CleanBlog.Business.Dtos.PostDtos;

public class PostGetDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int UserId { get; set; }
}
