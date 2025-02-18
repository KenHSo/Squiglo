﻿using Microsoft.EntityFrameworkCore;
using Squiglo.API.Models;

namespace Squiglo.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

}
