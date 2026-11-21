using ForoMy.Infrastructure.Identity;
using ForoMy.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ForoMy.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
  {
    services.AddPersistence(config);
    services.AddForoMyIdentity();
    return services;
  }
}