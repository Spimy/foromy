using ForoMy.Core.Forums;
using Microsoft.Extensions.Options;

namespace ForoMy.Web.ForumResolution;

internal sealed class ForumResolutionMiddleware(
  IOptions<ForumOptions> options,
  CurrentForum currentForum,
  IForumRepository forums
) : IMiddleware
{
  private readonly string _baseDomain = options.Value.BaseDomain.ToLowerInvariant();
  private string Suffix => $".{_baseDomain}";

  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    var host = context.Request.Host.Host.ToLowerInvariant();
    if (host == _baseDomain)
    {
      await next(context);
      return;
    }

    if (!host.EndsWith(Suffix, StringComparison.Ordinal))
    {
      context.Response.StatusCode = StatusCodes.Status404NotFound;
      return;
    }

    // cut off the suffix from the string
    // e.g. suffix = .example.com => subdomain.example.com -> subdomain
    var subdomain = host[..^Suffix.Length];

    var forumInfo = await forums.FindInfoBySubdomainAsync(subdomain, context.RequestAborted);
    if (forumInfo is null)
    {
      context.Response.StatusCode = StatusCodes.Status404NotFound;
      return;
    }

    currentForum.Forum = forumInfo;
    await next(context);
  }
}
