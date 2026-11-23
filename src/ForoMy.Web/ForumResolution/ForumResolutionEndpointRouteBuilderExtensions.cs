using ForoMy.Web.ForumResolution;
using Microsoft.Extensions.Options;

internal static class ForumResolutionEndpointRouteBuilderExtensions
{
  public static IEndpointRouteBuilder MapForumResolutionRoutes(this IEndpointRouteBuilder endpoints)
  {
    var baseDomain = endpoints.ServiceProvider
      .GetRequiredService<IOptions<ForumOptions>>()
      .Value.BaseDomain;

    endpoints.MapAreaControllerRoute(
      name: "landing",
      areaName: "Landing",
      pattern: "{Controller=Home}/{action=Index}/{Id?}"
    )
    .RequireHost(baseDomain)
    .WithStaticAssets();

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{Controller=Home}/{action=Index}/{Id?}"
    )
    .RequireHost($"*.{baseDomain}")
    .WithStaticAssets();

    return endpoints;
  }
}