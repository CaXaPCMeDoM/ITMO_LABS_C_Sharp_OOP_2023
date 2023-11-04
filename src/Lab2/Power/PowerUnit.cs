namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public class PowerUnit
{
    public PowerUnit(int peakLoad)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; private set; }
    public PowerUnit Clone()
    {
        return new PowerUnit(PeakLoad)
        {
            PeakLoad = PeakLoad,
        };
    }

    public PowerUnitBuilder Debuilder()
    {
        return new PowerUnitBuilder()
            .PeakLoad(PeakLoad);
    }
}