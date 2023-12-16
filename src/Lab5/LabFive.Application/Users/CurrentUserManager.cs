using LabFive.Application.Contracts.Users;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}