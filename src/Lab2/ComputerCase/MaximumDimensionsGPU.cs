namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class MaximumDimensionsGpu
{
    public MaximumDimensionsGpu(int maxLengthGpu, int maxWidthGpu)
    {
        MaxLengthGpu = maxLengthGpu;
        MaxWidthGpu = maxWidthGpu;
    }

    public int MaxLengthGpu { get; protected set; }
    public int MaxWidthGpu { get; protected set; }
}