namespace ForoMy.Core.Common.Results;

public sealed record Error(string Code, string? Description = null)
{
  public static readonly Error None = new(string.Empty);
  public static implicit operator Result(Error error) => Result.Failure(error);
}
