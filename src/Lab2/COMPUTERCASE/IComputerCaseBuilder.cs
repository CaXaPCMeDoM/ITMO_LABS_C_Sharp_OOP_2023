using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public interface IComputerCaseBuilder
{
    ComputerCaseBuilder MaximumDimensionsGpu(int length, int weight);
    ComputerCaseBuilder SupportedFormFactors(Collection<string>? supportedFormFactors);

    ComputerCaseBuilder Dimensions(int width, int height, int length);

    ComputerCase Build();
}