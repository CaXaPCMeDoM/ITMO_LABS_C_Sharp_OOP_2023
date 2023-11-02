using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class ComputerCase
{
    public ComputerCase(int maxLengthGpu, int maxWidthGpu, ICollection<string>? supportedFormFactor, Dimensions dimensions)
    {
        MaximumDimensionsGpu = new MaximumDimensionsGpu(maxLengthGpu, maxWidthGpu);
        SupportedFormFactors = supportedFormFactor;
        Dimensions = dimensions;
    }

    public MaximumDimensionsGpu MaximumDimensionsGpu { get; private set; }
    public ICollection<string>? SupportedFormFactors { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public ComputerCase Clone()
    {
        return new ComputerCase(MaximumDimensionsGpu.MaxLengthGpu, MaximumDimensionsGpu.MaxWidthGpu, SupportedFormFactors, Dimensions)
        {
            MaximumDimensionsGpu = MaximumDimensionsGpu,
            SupportedFormFactors = SupportedFormFactors,
            Dimensions = Dimensions,
        };
    }

    public ComputerCaseBuilder Debuilder()
    {
        return new ComputerCaseBuilder()
            .MaximumLengthGpu(MaximumDimensionsGpu.MaxLengthGpu)
            .MaximumWeightGpu(MaximumDimensionsGpu.MaxWidthGpu)
            .SupportedFormFactors((Collection<string>?)SupportedFormFactors)
            .DimensionsHeight(Dimensions.Height)
            .DimensionsLength(Dimensions.Length)
            .DimensionsWidth(Dimensions.Width);
    }
}