using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ForoMy.Core;

public static class DependencyInjection
{
  public static IServiceCollection AddCore(this IServiceCollection services)
  {
    var assembly = typeof(DependencyInjection).Assembly;
    services.AddValidatorsFromAssembly(assembly);

    return services;
  }
}