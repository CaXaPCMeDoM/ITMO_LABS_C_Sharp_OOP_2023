namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public interface IRamBuilder
{
    RamBuilder RamSize(double ramSize);

    RamBuilder SupportedFrequencyAndVoltage(int frequency, double voltage);

    RamBuilder AvailableProfiles(string profile, double timings, double voltage, int frequency);

    RamBuilder FormFactor(string formFactor);

    RamBuilder DdrVersion(string ddrVersion);

    RamBuilder PowerConsumption(double powerConsumption);
    Ram Build();
}