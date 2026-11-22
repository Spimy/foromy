namespace ForoMy.Web.ForumResolution;

internal static class ForumResolutionApplicationBuilderExtensions
{

  public static IApplicationBuilder UseForumResolution(this IApplicationBuilder app)
  {
    app.UseMiddleware<ForumResolutionMiddleware>();
    return app;
  }
}