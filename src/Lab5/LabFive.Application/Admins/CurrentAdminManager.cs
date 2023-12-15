using LabFive.Application.Contracts.Admins;
using LabFive.Application.Models.Admins;

namespace LabFive.Application.Admins;

public class CurrentAdminManager : ICurrentAdminService
{
    public Admin? Admin { get; set; }
}