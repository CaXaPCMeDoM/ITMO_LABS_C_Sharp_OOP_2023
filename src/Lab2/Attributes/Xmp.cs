namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public class Xmp
{
    public Xmp(double timings, double voltage, int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public double Timings { get; protected set; }
    public double Voltage { get; protected set; }
    public int Frequency { get; protected set; }
}