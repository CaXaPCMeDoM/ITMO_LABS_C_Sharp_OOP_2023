using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    internal ComputerCaseBuilder()
    {
        ComputerCase = new ComputerCase();
    }

    private ComputerCase ComputerCase { get; set; }
    public ComputerCaseBuilder MaximumDimensionsGpu(int length, int weight)
    {
        ComputerCase.MaximumDimensionsGpu.MaxLengthGPU = length;
        ComputerCase.MaximumDimensionsGpu.MaxWidthGPU = weight;
        return this;
    }

    public ComputerCaseBuilder SupportedFormFactors(Collection<string>? supportedFormFactors)
    {
        if (supportedFormFactors is not null)
        {
            foreach (string formFactor in supportedFormFactors)
            {
                ComputerCase.SupportedFormFactors?.Add(formFactor);
            }
        }

        return this;
    }

    public ComputerCaseBuilder Dimensions(int width, int height, int length)
    {
        ComputerCase.Dimensions.Width = width;
        ComputerCase.Dimensions.Height = height;
        ComputerCase.Dimensions.Length = length;
        return this;
    }

    public ComputerCase Build()
    {
        return ComputerCase;
    }
}