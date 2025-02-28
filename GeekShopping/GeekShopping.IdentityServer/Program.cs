using GeekShopping.IdentityServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.Services.InitializeDatabase();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
