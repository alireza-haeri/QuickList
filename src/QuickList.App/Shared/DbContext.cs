using Microsoft.EntityFrameworkCore;
using QuickList.App.Shared.Entities;

namespace QuickList.App.Shared;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }
}
