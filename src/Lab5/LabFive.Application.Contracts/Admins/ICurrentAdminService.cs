using LabFive.Application.Models.Admins;

namespace LabFive.Application.Contracts.Admins;

public interface ICurrentAdminService
{
    Admin? Admin { get; }
}