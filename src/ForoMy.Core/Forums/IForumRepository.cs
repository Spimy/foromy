using ForoMy.Core.Entities;

namespace ForoMy.Core.Forums;

public interface IForumRepository
{
  Task<ForumInfo?> FindInfoBySubdomainAsync(string subdomain, CancellationToken cancellationToken = default);
  Task<Forum?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
  Task<bool> SubdomainExistsAsync(string subdomain, CancellationToken cancellationToken = default);
  Task AddAsync(Forum forum, CancellationToken cancellationToken = default);
}