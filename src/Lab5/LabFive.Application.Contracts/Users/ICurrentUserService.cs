using LabFive.Application.Models.Users;

namespace LabFive.Application.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}