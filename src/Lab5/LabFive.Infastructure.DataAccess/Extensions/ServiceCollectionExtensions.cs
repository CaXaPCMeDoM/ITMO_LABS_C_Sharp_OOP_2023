using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using LabFive.Application.Abstractions.Repositories;
using LabFive.Infastructure.DataAccess.Plugins;
using LabFive.Infastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LabFive.Infastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IAdminRepository, AdminRepository>();

        return collection;
    }
}