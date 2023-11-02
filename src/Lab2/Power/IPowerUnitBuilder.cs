namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public interface IPowerUnitBuilder
{
    protected PowerUnitBuilder PeakLoad(int peakLoad);

    protected PowerUnit Builder();
}