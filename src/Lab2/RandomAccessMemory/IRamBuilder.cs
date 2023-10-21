namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public interface IRamBuilder
{
    public RamBuilder RamSize(double ramSize);

    public RamBuilder SupportedFrequencyAndVoltage(int frequency, double voltage);

    public RamBuilder AvailableProfiles(string profile, double timings, double voltage, int frequency);

    public RamBuilder FormFactor(string formFactor);

    public RamBuilder DdrVersion(string ddrVersion);

    public RamBuilder PowerConsumption(double powerConsumption);
    public Ram Build();
}