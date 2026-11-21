using ForoMy.Core.Entities;
using ForoMy.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForoMy.Infrastructure.Persistence;

public class ForoMyDbContext(DbContextOptions<ForoMyDbContext> options)
  : IdentityDbContext<ForoMyUser, ForoMyRole, Guid>(options)
{
  public DbSet<Forum> Forums => Set<Forum>();
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForoMyDbContext).Assembly);
  }
}