using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public class Chipset
{
    private IEnumerable<Ram> _supportRamFrequencies;
    private Xmp? _supportXmp;

    public Chipset()
    {
        _supportRamFrequencies = new List<Ram>();
        _supportXmp = null;
    }

    public string? BiosType { get; protected set; }
    public string? BiosVersion { get; protected set; }
    public IEnumerable<Ram> SupportRamFrequencies => _supportRamFrequencies;
    public Xmp? SupportXmp => _supportXmp;
    public void AddSupportedRamFrequencies(Collection<Ram> supportedFrequencies)
    {
        foreach (Collection<Ram> collection in new[] { supportedFrequencies }) _supportRamFrequencies = _supportRamFrequencies.Concat<Ram>(collection);
    }

    public void StateСhangeSupportXmp(Xmp? supportXmp)
    {
        _supportXmp = supportXmp;
    }
}