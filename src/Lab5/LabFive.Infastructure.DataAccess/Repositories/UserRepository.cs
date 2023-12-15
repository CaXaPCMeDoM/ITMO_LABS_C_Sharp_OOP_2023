using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Models.Users;
using Npgsql;

namespace LabFive.Infastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByUsername(string username)
    {
        const string sql = """
                           select user_id, user_name, user_amount, password
                           from users
                           where user_name = @username;
                           """;
        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            Amount: reader.GetDouble(2),
            Password: reader.GetString(3));
    }

    public User? CreatingAccount(string username, double useramount, string userpassword)
    {
        const string sql = """
                           INSERT INTO users (user_name, user_amount, user_password)
                           VALUES (@user_name, @user_amount, @user_password)
                           RETURNING user_id;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("user_name", username);
        command.AddParameter("user_amount", useramount);
        command.AddParameter("user_password", userpassword);

        long userId = (long)command.ExecuteScalar() ?? 0;

        return new User(userId, username, useramount, userpassword);
    }

    public double? ViewingTheAccountBalanceByAccountId(long id)
    {
        const string sql = """
                           select user_id, user_amount
                           from users
                           where user_id = @userid;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userid", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return reader.GetDouble(reader.GetOrdinal("user_amount"));
        }
        else
        {
            return null;
        }
    }

    public void WithdrawingMoneyFromTheAccount(long id, double amountToWithdraw)
    {
        const string sql = """
                            update users
                            set user_amount = user_amount - @amount
                            where user_id = @userid
                            returning user_amount;
                           """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userid", id);
        command.AddParameter("amount", amountToWithdraw);

        using NpgsqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            AddOperationDetail(connection, OperationType.Withdrawing, id, amountToWithdraw);
        }
    }

    public void AddingFundsToYourAccount(long id, double amountToAdd)
    {
        const string sql = """
                       update users
                       set user_amount = user_amount + @amount
                       where user_id = @userid
                       returning user_amount;
                       """;

        using NpgsqlConnection connection = Task
            .Run(async () =>
                await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false)).GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userid", id);
        command.AddParameter("amount", amountToAdd);

        using NpgsqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            AddOperationDetail(connection, OperationType.Deposit, id, amountToAdd);
        }
    }

    private static void AddOperationDetail(NpgsqlConnection connection, OperationType operationType, long userId, double operationAmount)
    {
        const string sqlInsert = """
                                 insert into operation_detail (operation_type, user_id, operation_amount)
                                 values (@operationType, @userId, @operationAmount);
                                 """;

        using var commandInsert = new NpgsqlCommand(sqlInsert, connection);
        commandInsert.AddParameter("operationType", operationType);
        commandInsert.AddParameter("userId", userId);
        commandInsert.AddParameter("operationAmount", operationAmount);

        commandInsert.ExecuteNonQuery();
    }
}