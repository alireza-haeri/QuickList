using Microsoft.EntityFrameworkCore;
using QuickList.App.Shared.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<Todo> Todos { get; set; }
}
