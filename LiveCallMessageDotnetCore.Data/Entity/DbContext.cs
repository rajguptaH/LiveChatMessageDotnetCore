
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiveCallMessageDotnetCore.Data.Entity
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }

    public class AppUser : IdentityUser
    {
        public Guid CometUID { get; set; }
        public string Name { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid CometUID { get; set; }
        public string Name { get; set; }
    }
}
