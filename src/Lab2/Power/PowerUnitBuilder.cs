namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    internal PowerUnitBuilder()
    {
        PowerUnit = new Power.PowerUnit();
    }

    private Power.PowerUnit PowerUnit { get; set; }

    public PowerUnitBuilder PeakLoad(int peakLoad)
    {
        PowerUnit.PeakLoad = peakLoad;
        return this;
    }

    public Power.PowerUnit Builder()
    {
        return PowerUnit;
    }
}