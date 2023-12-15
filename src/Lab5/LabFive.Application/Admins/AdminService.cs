using LabFive.Application.Abstractions.Repositories;
using LabFive.Application.Contracts.Admins;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository repository)
    {
        _adminRepository = repository;
    }

    public IEnumerable<OperationDetail> GetHistoryOperation(long userid)
    {
        return _adminRepository.ViewingTheHistoryOfOperations(userid);
    }
}