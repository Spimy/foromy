using ForoMy.Core.Common.Interfaces;
using ForoMy.Core.Forums;

namespace ForoMy.Web.ForumResolution;

internal sealed class CurrentForum : ICurrentForum
{
  public ForumInfo? Forum { get; set; }
}
