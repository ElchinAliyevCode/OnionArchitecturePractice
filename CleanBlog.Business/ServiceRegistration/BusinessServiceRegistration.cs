using CleanBlog.Business.Services.Abstractions;
using CleanBlog.Business.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace CleanBlog.Business.ServiceRegistration;

public static class BusinessServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddAutoMapper(_ => { }, typeof(BusinessServiceRegistration).Assembly);
    }

}
