using ForoMy.Core.Entities;
using ForoMy.Core.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ForoMy.Infrastructure.Persistence.Repositories;

internal sealed class ForumRepository(ForoMyDbContext dbContext) : IForumRepository
{
  public Task<Guid?> FindIdBySubdomain(string subdomain, CancellationToken cancellationToken = default)
  {
    return dbContext.Forums
      .Where(forum => forum.Subdomain == subdomain)
      .Select(forum => (Guid?)forum.Id)
      .FirstOrDefaultAsync(cancellationToken);
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