using LabFive.Application.Models.Users;

namespace LabFive.Application.Contracts.Admins;

public interface IAdminService
{
    IEnumerable<OperationDetail> GetHistoryOperation(long userid);
    LoginResult Login(string password);
}