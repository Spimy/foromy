namespace ForoMy.Infrastructure.Persistence.Seeding;

public static class DevelopmentDataSeeder
{
  public static async Task SeedDevelopmentDataAsync(
    this IServiceProvider services,
    CancellationToken cancellationToken = default
  )
  {
    await services.SeedDevelopmentForumAsync(cancellationToken);
  }
}
