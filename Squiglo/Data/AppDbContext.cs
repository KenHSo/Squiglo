using Microsoft.EntityFrameworkCore;
using Squiglo.Models;

namespace Squiglo.Data;

public class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

}
