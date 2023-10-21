namespace Itmo.ObjectOrientedProgramming.Lab2.Power;

public class PowerUnit
{
    public int PeakLoad { get; set; }
    public PowerUnit Clone()
    {
        return new PowerUnit()
        {
            PeakLoad = PeakLoad,
        };
    }
}