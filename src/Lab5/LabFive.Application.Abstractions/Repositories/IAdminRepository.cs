using System.Collections.ObjectModel;
using LabFive.Application.Models.Admins;
using LabFive.Application.Models.Users;

namespace LabFive.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Collection<OperationDetail> ViewingTheHistoryOfOperations(long userId);
    Admin? CheckByPassword(string password);
}