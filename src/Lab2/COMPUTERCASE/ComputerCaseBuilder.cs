using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private int _maxLengthGpu;
    private int _maxWidthGpu;
    private ICollection<string>? _supportedFormFactors = new List<string>();
    private Dimensions _dimensions = new Dimensions();

    public ComputerCaseBuilder MaximumDimensionsGpu(int length, int weight)
    {
        _maxLengthGpu = length;
        _maxWidthGpu = weight;
        return this;
    }

    public ComputerCaseBuilder SupportedFormFactors(Collection<string>? supportedFormFactors)
    {
        if (supportedFormFactors is not null)
        {
            foreach (string formFactor in supportedFormFactors)
            {
                _supportedFormFactors?.Add(formFactor);
            }
        }

        return this;
    }

    public ComputerCaseBuilder Dimensions(int width, int height, int length)
    {
        _dimensions.Width = width;
        _dimensions.Height = height;
        _dimensions.Length = length;

        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _maxLengthGpu,
            _maxWidthGpu,
            _supportedFormFactors,
            _dimensions);
    }
}