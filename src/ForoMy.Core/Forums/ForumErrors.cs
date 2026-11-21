using ForoMy.Core.Common.Results;
using ForoMy.Core.Entities;

namespace ForoMy.Core.Forums;

public static class ForumErrors
{
  public static readonly Error MissingName = new("Forum.MissingName", "Forum name is required.");
  public static readonly Error InvalidNameLength = new("Forum.InvalidNameLength", $"Forum name must be at most {Forum.NameMaxLength} characters.");
  public static readonly Error MissingSubdomain = new("Forum.MissingSubdomain", "Subdomain is required.");
  public static readonly Error InvalidSubdomainLength = new("Forum.InvalidSubdomainLength", $"Subdomain must be at most {Forum.SubdomainMaxLength} characters.");
  public static readonly Error HyphenatedEdgeSubdomain = new("Forum.HyphenatedEdgeSubdomain", "Subdomain cannot start or end with hyphens.");
  public static readonly Error InvalidSubdomain = new("Forum.InvalidSubdomain", "Subdomain can only contain lowercase letters, numbers and hyphens.");
  public static readonly Error ReservedSubdomain = new("Forum.ReservedSubdomain", "That subdomain is reserved.");
}
