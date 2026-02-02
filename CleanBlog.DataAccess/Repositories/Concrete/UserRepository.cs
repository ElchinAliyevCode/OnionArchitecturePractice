using CleanBlog.Core.Entities;
using CleanBlog.DataAccess.Contexts;
using CleanBlog.DataAccess.Repositories.Abstractions;
using CleanBlog.DataAccess.Repositories.Concrete.Generic;

namespace CleanBlog.DataAccess.Repositories.Concrete;

public class UserRepository:Repository<User>,IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context):base(context)
    {
        _context = context;
    }
}
