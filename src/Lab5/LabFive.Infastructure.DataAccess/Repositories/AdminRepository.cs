using System.Collections.ObjectModel;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Models.Admins;
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

    public Admin? CheckByPassword(string password)
    {
        const string sql = """
                           select admin_password
                           from admins
                           where admin_password = @password;
                           """;
        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("password", password);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Admin(
            Password: reader.GetString(0));
    }

    public Collection<OperationDetail> ViewingTheHistoryOfOperations(long userId)
    {
        const string sql = """
                       select operation_id, user_id, operation_amount
                       from operation_detail
                       where user_id = :userId;
                       """;

        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 6432,
            Username = "postgres",
            Password = "postgres",
            SslMode = SslMode.Prefer,
        }.ConnectionString);

        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userId", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        var operations = new Collection<OperationDetail>();

        while (reader.Read())
        {
            var operation = new OperationDetail(
                OperationId: reader.GetInt64(0),
                UserId: reader.GetInt64(1),
                OperationAmount: reader.GetDouble(2));

            operations.Add(operation);
        }

        return operations;
    }
}