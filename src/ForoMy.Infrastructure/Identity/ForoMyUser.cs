using Microsoft.AspNetCore.Identity;

namespace ForoMy.Infrastructure.Identity;

public class ForoMyUser : IdentityUser<Guid>
{
  public Guid ForumId { get; set; }
  public DateTime CreatedAt { get; init; }
  public DateTime UpdatedAt { get; set; }
}
