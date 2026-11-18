using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ForoMy.Infrastructure.Persistence;

internal static class PersistenceServiceCollectionExtensions
{
  public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
  {
    var connectionString = config.GetConnectionString("Database")
      ?? throw new InvalidOperationException("Connection string 'Database' is not configured.");

    var dbOptions = config.GetRequiredSection("Database").Get<DatabaseOptions>();
    var provider = dbOptions?.Provider
      ?? throw new InvalidOperationException("'Database:Provider' is not configured.");

    if (!Enum.IsDefined(provider))
    {
      throw new InvalidOperationException($"'Database:Provider' has an unsupported value '{provider}'.");
    }

    services.AddDbContext<ForoMyDbContext>(options =>
    {
      switch (provider)
      {
        case DatabaseProvider.SqlServer: options.UseSqlServer(connectionString); break;
        case DatabaseProvider.AzureSql: options.UseAzureSql(connectionString); break;
        default: throw new InvalidOperationException($"Database provider '{provider}' is not handled.");
      }
    });

    return services;
  }
}