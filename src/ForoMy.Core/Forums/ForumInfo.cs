namespace ForoMy.Core.Forums;

public sealed record ForumInfo(Guid Id, string Name, string Subdomain, DateTime CreatedAt, DateTime UpdatedAt);
