namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public interface IRamBuilder
{
    RamBuilder RamSize(double ramSize);

    RamBuilder SupportedFrequencyAndVoltage(int frequency, double voltage);

    public RamBuilder AvailableProfile(string profile);
    public RamBuilder AvailableTimings(double timings);
    public RamBuilder AvailableVoltage(double voltage);
    public RamBuilder AvailableFrequency(int frequency);

    RamBuilder FormFactor(string formFactor);

    RamBuilder DdrVersion(string ddrVersion);

    RamBuilder PowerConsumption(double powerConsumption);
    Ram Build();
}