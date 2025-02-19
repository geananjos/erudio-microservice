using GeekShopping.IdentityServer.Data;
using GeekShopping.IdentityServer.Initializer;
using GeekShopping.IdentityServer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SqlContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("SqlConnection")["SqlConnectionString"]));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<SqlContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbInitializer.Initialize();
}

app.Run();