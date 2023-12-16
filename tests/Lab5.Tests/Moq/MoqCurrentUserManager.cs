using LabFive.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moq;

internal class MoqCurrentUserManager : IMoqCurrentUserService
{
    public User? User { get; set; }
}