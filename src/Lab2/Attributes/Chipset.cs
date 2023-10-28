using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public class Chipset
{
    private IEnumerable<string> _supportRamFrequencies;
    private bool _supportXmp;

    public Chipset()
    {
        _supportRamFrequencies = new List<string>();
        _supportXmp = false;
    }

    public string? BiosType { get; protected set; }
    public string? BiosVersion { get; protected set; }
    public IEnumerable<string> SupportRamFrequencies => _supportRamFrequencies;
    public bool SupportXmp => _supportXmp;
    public void AddSupportedRamFrequencies(Collection<string> supportedFrequencies)
    {
        foreach (Collection<string> collection in new[] { supportedFrequencies }) _supportRamFrequencies = _supportRamFrequencies.Concat<string>(collection);
    }

    public void StateСhangeSupportXmp(bool supportXmp)
    {
        _supportXmp = supportXmp;
    }
}