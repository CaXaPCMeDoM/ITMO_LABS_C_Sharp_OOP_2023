using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processors;

public class Processor
{
    private IEnumerable<int> _supportedMemoryFrequencies;

    public Processor()
    {
        _supportedMemoryFrequencies = new List<int>();
    }

    public string? Name { get; set; }

    public int CoreFrequency { get; set; }
    public int Cores { get; set; }
    public string? Socket { get; set; }
    public bool IntegratedGraphics { get; set; }
    public IEnumerable<int> SupportedMemoryFrequencies => _supportedMemoryFrequencies;
    public int Tdp { get; set; }
    public int PowerConsumption { get; set; }

    public Processor Clone()
    {
        return new Processor()
        {
            Name = Name,
            PowerConsumption = PowerConsumption,
            CoreFrequency = CoreFrequency,
            Cores = Cores,
            Socket = Socket,
            IntegratedGraphics = IntegratedGraphics,
            Tdp = Tdp,
        };
    }

    public void AddSupportedMemoryFrequencies(Collection<int> supportedFrequencies)
    {
        foreach (Collection<int> collection in new[] { supportedFrequencies }) _supportedMemoryFrequencies = _supportedMemoryFrequencies.Concat<int>(collection);
    }
}