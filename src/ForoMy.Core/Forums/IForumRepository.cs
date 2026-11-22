using ForoMy.Core.Entities;

namespace ForoMy.Core.Forums;

public interface IForumRepository
{
  Task<Guid?> FindIdBySubdomain(string subdomain, CancellationToken cancellationToken = default);
  Task<bool> SubdomainExistsAsync(string subdomain, CancellationToken cancellationToken = default);
  Task AddAsync(Forum forum, CancellationToken cancellationToken = default);
}