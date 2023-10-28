namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class MaximumDimensionsGPU
{
    public MaximumDimensionsGPU(int maxLengthGpu, int maxWidthGpu)
    {
        MaxLengthGPU = maxLengthGpu;
        MaxWidthGPU = maxWidthGpu;
    }

    public int MaxLengthGPU { get; protected set; }
    public int MaxWidthGPU { get; protected set; }
}