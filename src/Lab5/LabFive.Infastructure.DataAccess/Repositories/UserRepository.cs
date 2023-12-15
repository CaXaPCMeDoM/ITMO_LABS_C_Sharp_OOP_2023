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

    public User? LoginUserByUsernameAndPassword(string username, string password)
    {
        const string sql = """
                           select user_id, user_name, user_amount, user_password
                           from users
                           where user_name = @username and user_password = @password;
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
        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("password", password);

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
        command.AddParameter("user_name", username);
        command.AddParameter("user_amount", useramount);
        command.AddParameter("user_password", userpassword);

        object? result = command.ExecuteScalar();
        if (result == null)
        {
            return null;
        }

        long userId = (long)result;

        return new User(userId, username, useramount, userpassword);
    }

    public double? ViewingTheAccountBalanceByAccountId(long id)
    {
        const string sql = """
                           select user_id, user_amount
                           from users
                           where user_id = @userid;
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
        command.AddParameter("userid", id);
        command.AddParameter("amount", amountToWithdraw);

        using NpgsqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            AddOperationDetailForWithdrawingMoney(connection, id, amountToWithdraw);
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
        command.AddParameter("userid", id);
        command.AddParameter("amount", amountToAdd);

        double updatedAmount = 0;
        using (NpgsqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                updatedAmount = (double)reader[0];
            }
        }

        AddOperationDetailForAddingFounds(connection, id, amountToAdd);
    }

    private static void AddOperationDetailForAddingFounds(NpgsqlConnection connection, long userId, double operationAmount)
    {
        const string sqlInsert = """
                                 insert into operation_detail (user_id, operation_amount)
                                 values (@userId, @operationAmount);
                                 """;

        using var commandInsert = new NpgsqlCommand(sqlInsert, connection);
        commandInsert.AddParameter("userId", userId);
        commandInsert.AddParameter("operationAmount", operationAmount);

        commandInsert.ExecuteNonQuery();
    }

    private static void AddOperationDetailForWithdrawingMoney(NpgsqlConnection connection, long userId, double operationAmount)
    {
        const string sqlInsert = """
                                 insert into operation_detail (user_id, operation_amount)
                                 values (@userId, @operationAmount);
                                 """;

        using var commandInsert = new NpgsqlCommand(sqlInsert, connection);
        commandInsert.AddParameter("userId", userId);
        commandInsert.AddParameter("operationAmount", -operationAmount);

        commandInsert.ExecuteNonQuery();
    }
}