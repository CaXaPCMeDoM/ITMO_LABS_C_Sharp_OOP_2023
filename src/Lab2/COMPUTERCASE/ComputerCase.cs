using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class ComputerCase
{
    public MaximumDimensionsGPU MaximumDimensionsGpu { get; init; } = new MaximumDimensionsGPU();
    public ICollection<string>? SupportedFormFactors { get; init; } = new List<string>();
    public Dimensions Dimensions { get; init; } = new Dimensions();
    public ComputerCase Clone()
    {
        return new ComputerCase()
        {
            MaximumDimensionsGpu = MaximumDimensionsGpu,
            SupportedFormFactors = SupportedFormFactors,
            Dimensions = Dimensions,
        };
    }
}