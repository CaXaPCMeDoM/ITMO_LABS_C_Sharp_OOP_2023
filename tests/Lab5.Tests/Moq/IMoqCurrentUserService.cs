using LabFive.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;

public interface IMoqCurrentUserService
{
    User? User { get; }
}