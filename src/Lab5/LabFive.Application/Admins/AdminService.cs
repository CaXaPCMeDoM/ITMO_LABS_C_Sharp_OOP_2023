using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Contracts;
using LabFive.Application.Contracts.Admins;
using LabFive.Application.Models.Admins;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly CurrentAdminManager _currentAdminManager;

    public AdminService(IAdminRepository repository, CurrentAdminManager currentAdminManager)
    {
        _adminRepository = repository;
        _currentAdminManager = currentAdminManager;
    }

    public LoginResult Login(string password)
    {
        Admin? admin = _adminRepository.CheckByPassword(password);

        if (admin is null)
        {
            System.Environment.Exit(0);
        }

        _currentAdminManager.Admin = admin;
        return LoginResult.Success;
    }

    public IEnumerable<OperationDetail> GetHistoryOperation(long userid)
    {
        return _adminRepository.ViewingTheHistoryOfOperations(userid);
    }
}