using Microsoft.EntityFrameworkCore;

namespace ForoMy.Infrastructure.Persistence;

public class ForoMyDbContext(DbContextOptions<ForoMyDbContext> options) : DbContext(options)
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForoMyDbContext).Assembly);
  }
}