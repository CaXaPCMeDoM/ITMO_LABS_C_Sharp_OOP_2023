using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public class Bios
{
    private IEnumerable<Processor> _supportedProcessors;

    public Bios()
    {
        _supportedProcessors = new List<Processor>();
    }

    public string? BiosType { get; set; } = string.Empty;
    public string? BiosVersion { get; set; } = string.Empty;
    public IEnumerable<Processor> SupportedProcessors => _supportedProcessors;

    public void AddSupportedProcessors(Collection<Processor> supportedFrequencies)
    {
        foreach (Collection<Processor> collection in new[] { supportedFrequencies }) _supportedProcessors = _supportedProcessors.Concat<Processor>(collection);
    }
}