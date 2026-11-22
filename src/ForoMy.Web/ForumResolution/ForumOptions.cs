using System.ComponentModel.DataAnnotations;

namespace ForoMy.Web.ForumResolution;

internal sealed class ForumOptions
{
  [Required]
  public string BaseDomain { get; init; } = "";
}