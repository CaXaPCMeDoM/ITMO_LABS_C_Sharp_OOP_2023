using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public interface IComputerCaseBuilder
{
    ComputerCaseBuilder MaximumLengthGpu(int length);
    ComputerCaseBuilder MaximumWeightGpu(int weight);
    ComputerCaseBuilder SupportedFormFactors(Collection<string>? supportedFormFactors);

    ComputerCaseBuilder DimensionsWidth(int width);
    ComputerCaseBuilder DimensionsHeight(int height);
    ComputerCaseBuilder DimensionsLength(int length);

    ComputerCase Build();
}