using GeekShopping.IdentityServer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Data
{
    public class SqlContext : IdentityDbContext<ApplicationUser>
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
    }
}
