using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public class Bios
{
    private IEnumerable<Processor> _supportedProcessors;

    public Bios(string biosType, string biosVersion, Collection<Processor> supportedProcessors)
    {
        _supportedProcessors = supportedProcessors;
        BiosType = biosType;
        BiosVersion = biosVersion;
    }

    public string BiosType { get; private set; }
    public string BiosVersion { get; private set; }
    public IEnumerable<Processor> SupportedProcessors => _supportedProcessors;

    public void AddSupportedProcessors(Collection<Processor> supportedFrequencies)
    {
        foreach (Collection<Processor> collection in new[] { supportedFrequencies })
            _supportedProcessors = _supportedProcessors.Concat<Processor>(collection);
    }
}