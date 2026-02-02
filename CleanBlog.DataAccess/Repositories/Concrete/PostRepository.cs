using CleanBlog.Core.Entities;
using CleanBlog.DataAccess.Contexts;
using CleanBlog.DataAccess.Repositories.Abstractions;
using CleanBlog.DataAccess.Repositories.Concrete.Generic;

namespace CleanBlog.DataAccess.Repositories.Concrete;

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context):base(context)
    {
        _context = context;
    }
}
