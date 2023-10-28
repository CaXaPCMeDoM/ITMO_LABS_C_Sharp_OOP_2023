using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public class Bios
{
    private IEnumerable<string> _supportedProcessors;

    public Bios()
    {
        _supportedProcessors = new List<string>();
    }

    public string? BiosType { get; set; } = string.Empty;
    public string? BiosVersion { get; set; } = string.Empty;
    public IEnumerable<string> SupportedProcessors => _supportedProcessors;

    public void AddSupportedProcessors(Collection<string> supportedFrequencies)
    {
        foreach (Collection<string> collection in new[] { supportedFrequencies }) _supportedProcessors = _supportedProcessors.Concat<string>(collection);
    }
}