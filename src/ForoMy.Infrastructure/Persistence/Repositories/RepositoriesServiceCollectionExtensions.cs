using ForoMy.Core.Forums;
using Microsoft.Extensions.DependencyInjection;

namespace ForoMy.Infrastructure.Persistence.Repositories;

internal static class RepositoriesServiceCollectionExtensions
{
  public static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    services.AddScoped<IForumRepository, ForumRepository>();
    return services;
  }
}