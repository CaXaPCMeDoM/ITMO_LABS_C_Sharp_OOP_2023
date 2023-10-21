using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Sales;

public interface IMessenger
{
    static abstract ResultsProcessingOfPcComponents Send(ResultsProcessingOfPcComponents processingOfPcComponents);
}