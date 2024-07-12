using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCallMessageDotnetCore.Data.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
       : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }

    }


    public class Users
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid CometUID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
