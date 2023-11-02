using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public interface IRamBuilder
{
    protected RamBuilder RamSize(double ramSize);

    public RamBuilder SupportedFrequency(Collection<int> frequency);

    public RamBuilder SupportedVoltage(Collection<double> voltage);

    protected RamBuilder AvailableProfile(Collection<string> profile);
    protected RamBuilder AvailableTimings(double timings);
    protected RamBuilder AvailableVoltage(double voltage);
    protected RamBuilder AvailableFrequency(int frequency);

    protected RamBuilder FormFactor(string formFactor);

    protected RamBuilder DdrVersion(string ddrVersion);

    protected RamBuilder PowerConsumption(double powerConsumption);
    protected Ram Build();
}