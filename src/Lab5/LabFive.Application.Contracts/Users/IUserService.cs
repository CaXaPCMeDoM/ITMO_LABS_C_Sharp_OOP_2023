namespace LabFive.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string username);
}