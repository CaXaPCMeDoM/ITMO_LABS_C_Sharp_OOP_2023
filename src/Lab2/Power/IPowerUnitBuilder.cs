namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public interface IPowerUnitBuilder
{
    PowerUnitBuilder PeakLoad(int peakLoad);

    PowerUnit Builder();
}