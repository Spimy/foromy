using ForoMy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForoMy.Infrastructure.Persistence.Configurations;

internal class ForumConfiguration : IEntityTypeConfiguration<Forum>
{
  public void Configure(EntityTypeBuilder<Forum> builder)
  {
    builder.Property(forum => forum.Name).HasMaxLength(Forum.NameMaxLength);
    builder.Property(forum => forum.Subdomain).HasMaxLength(Forum.SubdomainMaxLength);
    builder.HasIndex(forum => forum.Subdomain).IsUnique();
  }
}