using ForoMy.Core.Entities;
using ForoMy.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForoMy.Infrastructure.Persistence.Configurations;

internal class ForoMyUserConfiguration : IEntityTypeConfiguration<ForoMyUser>
{
  public void Configure(EntityTypeBuilder<ForoMyUser> builder)
  {
    // Remove default uniqueness check from username because uniquess is checked together with forum
    builder.HasIndex(user => user.NormalizedUserName).IsUnique(false);

    builder.HasIndex(user =>
      new
      {
        user.ForumId,
        user.NormalizedEmail,
      }
    ).IsUnique();

    builder.HasIndex(user =>
      new
      {
        user.ForumId,
        user.NormalizedUserName
      }
    ).IsUnique();

    builder
      .HasOne<Forum>()
      .WithMany()
      .HasForeignKey(user => user.ForumId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}