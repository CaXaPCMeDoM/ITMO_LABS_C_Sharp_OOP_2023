using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Sales;

public class MessageToTheSalesDepartment : IMessenger
{
    public static ResultsProcessingOfPcComponents Send(ResultsProcessingOfPcComponents processingOfPcComponents)
    {
        return processingOfPcComponents;
    }
}