using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class ComputerCase
{
    public ComputerCase(int maxLengthGpu, int maxWidthGpu, ICollection<string>? supportedFormFactor, Dimensions dimensions)
    {
        MaximumDimensionsGpu = new MaximumDimensionsGPU(maxLengthGpu, maxWidthGpu);
        SupportedFormFactors = supportedFormFactor;
        Dimensions = dimensions;
    }

    public MaximumDimensionsGPU MaximumDimensionsGpu { get; protected init; }
    public ICollection<string>? SupportedFormFactors { get; protected init; }
    public Dimensions Dimensions { get; protected init; }
    public ComputerCase Clone()
    {
        return new ComputerCase(MaximumDimensionsGpu.MaxLengthGPU, MaximumDimensionsGpu.MaxWidthGPU, SupportedFormFactors, Dimensions)
        {
            MaximumDimensionsGpu = MaximumDimensionsGpu,
            SupportedFormFactors = SupportedFormFactors,
            Dimensions = Dimensions,
        };
    }
}