namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private int _peakLoad;

    public PowerUnitBuilder PeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public Power.PowerUnit Builder()
    {
        return new PowerUnit(_peakLoad);
    }
}