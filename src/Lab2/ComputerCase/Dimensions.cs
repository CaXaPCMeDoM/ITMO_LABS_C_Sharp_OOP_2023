namespace Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;

public class Dimensions
{
    public Dimensions(int width, int height, int length)
    {
        Width = width;
        Height = height;
        Length = length;
    }

    public int Width { get; private init; }
    public int Height { get; private init; }
    public int Length { get; private init; }
}