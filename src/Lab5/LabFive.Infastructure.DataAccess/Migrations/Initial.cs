using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace LabFive.Infastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type type_operation as enum
    (
        'withdrawing',
        'deposit'
    );

    create table users
    (
        user_id bigint primary key generated always as identity ,
        user_name text not null ,
        user_amount double precision not null ,
        user_password text not null
    );

    create table admins
    (
        admin_password text not null
    );

    create table operation_detail
    (
        operation_id bigint primary key generated always as identity ,
        operation_type type_operation is not null ,
        user_id bight not null ,
        operation_amount double precision
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table admins;
    drop table operation_detail;

    drop type type_operation;
    """;
}