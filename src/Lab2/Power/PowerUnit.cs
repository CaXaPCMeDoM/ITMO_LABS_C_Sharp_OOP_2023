namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public class PowerUnit
{
    public PowerUnit(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; protected set; }
    public PowerUnit Clone()
    {
        return new PowerUnit(PeakLoad)
        {
            PeakLoad = PeakLoad,
        };
    }
}