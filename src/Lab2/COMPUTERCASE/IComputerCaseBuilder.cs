using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public interface IComputerCaseBuilder
{
    public ComputerCaseBuilder MaximumDimensionsGpu(int length, int weight);

    public ComputerCaseBuilder SupportedFormFactors(Collection<string>? supportedFormFactors);

    public ComputerCaseBuilder Dimensions(int width, int height, int length);

    public ComputerCase Build();
}