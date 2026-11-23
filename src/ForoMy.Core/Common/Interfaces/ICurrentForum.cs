using ForoMy.Core.Forums;

namespace ForoMy.Core.Common.Interfaces;

public interface ICurrentForum
{
  ForumInfo? Forum { get; }
  ForumInfo RequiredForum => Forum
    ?? throw new InvalidOperationException("No forum was resolved for this request.");
}