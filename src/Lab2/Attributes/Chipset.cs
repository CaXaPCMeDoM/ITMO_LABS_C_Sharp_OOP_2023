using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public class Chipset
{
    public Chipset(Collection<Ram> supportRamFrequencies, Xmp? supportXmp)
    {
        SupportRamFrequencies = supportRamFrequencies;
        SupportXmp = supportXmp;
    }

    public string? BiosType { get; private set; }
    public string? BiosVersion { get; private set; }
    public Collection<Ram> SupportRamFrequencies { get; private set; }
    public Xmp? SupportXmp { get; private set; }
}