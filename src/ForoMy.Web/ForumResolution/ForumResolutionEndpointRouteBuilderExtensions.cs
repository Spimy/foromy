using Microsoft.Extensions.Options;

namespace ForoMy.Web.ForumResolution;

internal static class ForumResolutionEndpointRouteBuilderExtensions
{
  public static IEndpointRouteBuilder MapForumResolutionRoutes(this IEndpointRouteBuilder endpoints)
  {
    var baseDomain = endpoints.ServiceProvider
      .GetRequiredService<IOptions<ForumOptions>>()
      .Value.BaseDomain;

    endpoints.MapAreaControllerRoute(
      name: "error",
      areaName: "Landing",
      pattern: "error",
      defaults: new { controller = "Home", action = "Error" }
    )
    .WithStaticAssets();

    endpoints.MapAreaControllerRoute(
      name: "privacy",
      areaName: "Landing",
      pattern: "privacy",
      defaults: new { controller = "Home", action = "Privacy" }
    )
    .WithStaticAssets();

    endpoints.MapAreaControllerRoute(
      name: "landing",
      areaName: "Landing",
      pattern: "{controller=Home}/{action=Index}/{id?}"
    )
    .RequireHost(baseDomain)
    .WithStaticAssets();

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}"
    )
    .RequireHost($"*.{baseDomain}")
    .WithStaticAssets();

    return endpoints;
  }
}