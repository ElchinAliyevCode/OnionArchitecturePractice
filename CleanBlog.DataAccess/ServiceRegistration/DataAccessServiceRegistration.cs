using CleanBlog.DataAccess.Contexts;
using CleanBlog.DataAccess.Repositories.Abstractions;
using CleanBlog.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanBlog.DataAccess.ServiceRegistration;

public static class DataAccessServiceRegistration
{
    public static void AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
