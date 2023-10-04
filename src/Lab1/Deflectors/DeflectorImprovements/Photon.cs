namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class Photon
{
    public Photon()
    {
        IsActive = false;
        CounterAntimatter = 3;
    }

    public int CounterAntimatter { get; set; }
    public bool IsActive { get; set; }
}