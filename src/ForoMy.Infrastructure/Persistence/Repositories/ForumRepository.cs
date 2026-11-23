using ForoMy.Core.Entities;
using ForoMy.Core.Forums;
using Microsoft.EntityFrameworkCore;

namespace ForoMy.Infrastructure.Persistence.Repositories;

internal sealed class ForumRepository(ForoMyDbContext dbContext) : IForumRepository
{
  public Task<ForumInfo?> FindInfoBySubdomainAsync(string subdomain, CancellationToken cancellationToken = default)
  {
    return dbContext.Forums
      .Where(forum => forum.Subdomain == subdomain)
      .Select(forum => new ForumInfo(forum.Id, forum.Name, forum.Subdomain, forum.CreatedAt, forum.UpdatedAt))
      .FirstOrDefaultAsync(cancellationToken);
  }

  public Task<Forum?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return dbContext.Forums.FirstOrDefaultAsync(forum => forum.Id == id, cancellationToken);
  }

  public Task<bool> SubdomainExistsAsync(string subdomain, CancellationToken cancellationToken = default)
  {
    return dbContext.Forums.AnyAsync(forum => forum.Subdomain == subdomain, cancellationToken);
  }

  public async Task AddAsync(Forum forum, CancellationToken cancellationToken = default)
  {
    dbContext.Add(forum);
    await dbContext.SaveChangesAsync(cancellationToken);
  }
}