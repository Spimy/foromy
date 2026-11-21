using ForoMy.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace ForoMy.Infrastructure.Identity;

internal static class IdentityServiceCollectionExtensions
{
  public static IServiceCollection AddForoMyIdentity(this IServiceCollection services)
  {
    services.AddIdentity<ForoMyUser, ForoMyRole>(options =>
    {
      options.SignIn.RequireConfirmedAccount = false;
      options.User.RequireUniqueEmail = true;
      options.Password.RequiredLength = 8;
      options.Password.RequireDigit = true;
      options.Password.RequireNonAlphanumeric = true;
      options.Password.RequireLowercase = true;
      options.Password.RequireUppercase = true;
    })
    .AddEntityFrameworkStores<ForoMyDbContext>()
    .AddDefaultTokenProviders();

    return services;
  }
}
