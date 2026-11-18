using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ForoMy.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
  {
    return services;
  }
}