namespace LabFive.Application.Models.Users;

public record OperationDetail(long OperationId, string OperationType, long UserId, double OperationAmount);