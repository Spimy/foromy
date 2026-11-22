using ForoMy.Core.Common.Interfaces;

namespace ForoMy.Web.ForumResolution;

internal static class ForumResolutionServiceCollectionExtensions
{
  public static IServiceCollection AddForumResolution(this IServiceCollection services, IConfiguration config)
  {
    services.AddOptions<ForumOptions>()
      .Bind(config.GetSection("ForumResolution"))
      .ValidateDataAnnotations()
      .ValidateOnStart();

    services.AddScoped<CurrentForum>();
    services.AddScoped<ICurrentForum>(service => service.GetRequiredService<CurrentForum>());
    services.AddScoped<ForumResolutionMiddleware>();
    return services;
  }
}