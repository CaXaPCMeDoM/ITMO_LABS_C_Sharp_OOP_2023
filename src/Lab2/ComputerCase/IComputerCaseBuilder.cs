using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public interface IComputerCaseBuilder
{
    protected ComputerCaseBuilder MaximumLengthGpu(int length);
    protected ComputerCaseBuilder MaximumWeightGpu(int weight);
    protected ComputerCaseBuilder SupportedFormFactors(Collection<string>? supportedFormFactors);

    protected ComputerCaseBuilder DimensionsWidth(int width);
    protected ComputerCaseBuilder DimensionsHeight(int height);
    protected ComputerCaseBuilder DimensionsLength(int length);

    protected ComputerCase Build();
}