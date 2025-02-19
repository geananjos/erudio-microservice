using GeekShopping.IdentityServer.Data;
using GeekShopping.IdentityServer.Initializer;
using GeekShopping.IdentityServer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Extensions
{
    public static class HostingExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options =>
                options.UseSqlServer(configuration["SqlConnection:SqlConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SqlContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddIdentityServer()
                .AddAspNetIdentity<ApplicationUser>();
        }

        public static void InitializeDatabase(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                dbInitializer.Initialize();
            }
        }
    }
}