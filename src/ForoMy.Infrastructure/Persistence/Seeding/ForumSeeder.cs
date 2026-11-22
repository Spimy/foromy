using ForoMy.Core.Entities;
using ForoMy.Core.Forums;
using Microsoft.Extensions.DependencyInjection;

namespace ForoMy.Infrastructure.Persistence.Seeding;

internal static class ForumSeeder
{
  private const string DevelopmentForumName = "Development";
  private const string DevelopmentForumSubdomain = "development";

  public static async Task SeedDevelopmentForumAsync(
    this IServiceProvider services,
    CancellationToken cancellationToken = default
  )
  {
    using var scope = services.CreateScope();
    var forums = scope.ServiceProvider.GetRequiredService<IForumRepository>();

    if (!await forums.SubdomainExistsAsync(DevelopmentForumSubdomain, cancellationToken))
    {
      var forum = Forum.Create(DevelopmentForumName, DevelopmentForumSubdomain);
      await forums.AddAsync(forum.Value, cancellationToken);
    }
  }
}
