using System;
using Microsoft.EntityFrameworkCore;
using Quizzler.Models;

namespace Quizzler.Contexts
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }
}
