using Itmo.Dev.Platform.Postgres.Plugins;
using LabFive.Application.Models.Users;
using Npgsql;

namespace LabFive.Infastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<OperationType>();
    }
}