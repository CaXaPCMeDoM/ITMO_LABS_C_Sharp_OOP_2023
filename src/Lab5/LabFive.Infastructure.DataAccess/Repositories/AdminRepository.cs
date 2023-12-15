using System.Collections.ObjectModel;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Models.Users;
using Npgsql;

namespace LabFive.Infastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Collection<OperationDetail> ViewingTheHistoryOfOperations(long userId)
    {
        const string sql = """
                       select operation_id, operation_type, user_id, operation_amount
                       from operation_detail
                       where user_id = :userId;
                       """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        var operations = new Collection<OperationDetail>();

        while (reader.Read())
        {
            var operation = new OperationDetail(
                OperationId: reader.GetInt64(0),
                OperationType: reader.GetString(1),
                UserId: reader.GetInt64(2),
                OperationAmount: reader.GetDouble(3));

            operations.Add(operation);
        }

        return operations;
    }
}