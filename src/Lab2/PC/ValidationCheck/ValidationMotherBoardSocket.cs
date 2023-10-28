using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.ValidationCheck;

public static class ValidationMotherBoardSocket
{
    public static ResultsProcessingOfPcComponents MotherBoardSocket(int totalSataPorts, int? requiredSataPorts, bool flagSupportSocket)
    {
        ResultsProcessingOfPcComponents result = ResultsProcessingOfPcComponents.None;
        if (totalSataPorts < requiredSataPorts)
        {
            result = ResultsProcessingOfPcComponents.SataCountError;
        }

        if (!flagSupportSocket)
        {
            result = ResultsProcessingOfPcComponents.SupportSocketError;
        }

        return result;
    }
}