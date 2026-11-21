using ForoMy.Core.Common.Results;
using ForoMy.Core.Forums;

namespace ForoMy.Core.Entities;

public sealed class Forum
{
  public const int NameMaxLength = 32;
  public const int SubdomainMaxLength = 32;
  private static readonly string[] ReservedSubdomains = ["admin", "www", "api"];

  public Guid Id { get; init; }
  public string Name { get; private set; }
  public string Subdomain { get; private set; }
  public DateTime CreatedAt { get; init; }
  public DateTime UpdatedAt { get; set; }

  private Forum(string name, string subdomain)
  {
    Name = name;
    Subdomain = subdomain;
  }

  public static Result<Forum> Create(string name, string subdomain)
  {
    name = name.Trim();
    var nameValidation = ValidateName(name);
    if (nameValidation.IsFailure) return nameValidation.Error;

    subdomain = NormaliseSubdomain(subdomain);
    var subdomainValidation = ValidateSubdomain(subdomain);
    if (subdomainValidation.IsFailure) return subdomainValidation.Error;

    return new Forum(name, subdomain);
  }

  public Result ChangeSubdomain(string subdomain)
  {
    subdomain = NormaliseSubdomain(subdomain);
    var validation = ValidateSubdomain(subdomain);
    if (validation.IsFailure) return validation;

    Subdomain = subdomain;
    return Result.Success();
  }


  private static Result ValidateName(string name)
  {
    if (string.IsNullOrEmpty(name)) return ForumErrors.MissingName;
    if (name.Length > NameMaxLength) return ForumErrors.InvalidNameLength;
    return Result.Success();
  }
  private static string NormaliseSubdomain(string subdomain) => subdomain.Trim().ToLowerInvariant();

  private static Result ValidateSubdomain(string subdomain)
  {
    if (string.IsNullOrEmpty(subdomain)) return ForumErrors.MissingSubdomain;
    if (subdomain.Length > SubdomainMaxLength) return ForumErrors.InvalidSubdomainLength;
    if (subdomain.StartsWith('-') || subdomain.EndsWith('-')) return ForumErrors.HyphenatedEdgeSubdomain;
    if (!subdomain.All(c => char.IsAsciiLetterLower(c) || char.IsAsciiDigit(c) || c == '-')) return ForumErrors.InvalidSubdomain;
    if (ReservedSubdomains.Contains(subdomain)) return ForumErrors.ReservedSubdomain;
    return Result.Success();
  }
}