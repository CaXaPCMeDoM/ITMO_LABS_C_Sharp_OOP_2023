using LabFive.Application.Admins;
using LabFive.Application.Contracts.Admins;
using LabFive.Application.Contracts.Users;
using LabFive.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LabFive.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        return collection;
    }
}