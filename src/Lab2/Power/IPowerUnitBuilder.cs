namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public interface IPowerUnitBuilder
{
    public PowerUnitBuilder PeakLoad(int peakLoad);

    public PowerUnit Builder();
}