using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processors;

public class Processor
{
    private IEnumerable<int> _supportedMemoryFrequencies;

    public Processor(
        string name,
        int coreFrequency,
        int cores,
        string socket,
        bool integratedGraphics,
        Collection<int> supportedMemoryFrequencies,
        int tdp,
        int powerConsumption)
    {
        CoreFrequency = coreFrequency;
        Name = name;
        Cores = cores;
        Socket = socket;
        IntegratedGraphics = integratedGraphics;
        Tdp = tdp;
        _supportedMemoryFrequencies = supportedMemoryFrequencies;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; private set; }

    public int CoreFrequency { get; private set; }
    public int Cores { get; private set; }
    public string Socket { get; private set; }
    public bool IntegratedGraphics { get; private set; }
    public IEnumerable<int> SupportedMemoryFrequencies => _supportedMemoryFrequencies;
    public int Tdp { get; private set; }
    public int PowerConsumption { get; private set; }

    public Processor Clone()
    {
        return new Processor(
            Name,
            CoreFrequency,
            Cores,
            Socket,
            IntegratedGraphics,
            (Collection<int>)_supportedMemoryFrequencies,
            Tdp,
            PowerConsumption)
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

    public ProcessorBuilder Debuilder()
    {
        return new ProcessorBuilder()
            .Name(Name)
            .PowerConsumption(PowerConsumption)
            .CoreFrequency(CoreFrequency)
            .Cores(Cores)
            .Socket(Socket)
            .IntegratedGraphics(IntegratedGraphics)
            .Tdp(Tdp);
    }
}