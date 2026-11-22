using ForoMy.Core.Common.Interfaces;

namespace ForoMy.Web.ForumResolution;

internal sealed class CurrentForum : ICurrentForum
{
  public Guid? ForumId { get; set; }
}
