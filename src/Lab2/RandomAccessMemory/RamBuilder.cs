using System;
using Itmo.ObjectOrientedProgramming.Lab2.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public class RamBuilder : IRamBuilder
{
    internal RamBuilder()
    {
        Xmp = new Xmp();
        Ram = new Ram();
    }

    private Xmp Xmp { get; set; }
    private Ram Ram { get; set; }

    public RamBuilder RamSize(double ramSize)
    {
        Ram.RamSize = ramSize;
        return this;
    }

    public RamBuilder SupportedFrequencyAndVoltage(int frequency, double voltage)
    {
        Ram.SupportedFrequenciesAndVoltages.Add(Tuple.Create(frequency, voltage));
        return this;
    }

    public RamBuilder AvailableProfiles(string profile, double timings, double voltage, int frequency)
    {
        Ram.AvailableProfiles.Add(profile);
        if (profile is not "")
        {
            Xmp.Timings = timings;
            Xmp.Voltage = voltage;
            Xmp.Frequency = frequency;
        }

        return this;
    }

    public RamBuilder FormFactor(string formFactor)
    {
        Ram.FormFactor = formFactor;
        return this;
    }

    public RamBuilder DdrVersion(string ddrVersion)
    {
        Ram.DdrVersion = ddrVersion;
        return this;
    }

    public RamBuilder PowerConsumption(double powerConsumption)
    {
        Ram.PowerConsumption = powerConsumption;
        return this;
    }

    public Ram Build()
    {
        return Ram;
    }
}