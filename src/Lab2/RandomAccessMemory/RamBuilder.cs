using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public class RamBuilder : IRamBuilder
{
    private double _ramSize;
    private Collection<Tuple<int, double>> _supportedFrequenciesAndVoltages = new();
    private Collection<string> _availableProfiles = new();
    private string _formFactor = string.Empty;
    private string _ddrVersion = string.Empty;
    private double _powerConsumption;
    private double _timings;
    private double _voltage;
    private int _frequency;

    public RamBuilder RamSize(double ramSize)
    {
        _ramSize = ramSize;
        return this;
    }

    public RamBuilder SupportedFrequencyAndVoltage(int frequency, double voltage)
    {
        _supportedFrequenciesAndVoltages.Add(Tuple.Create(frequency, voltage));
        return this;
    }

    public RamBuilder AvailableProfiles(string profile, double timings, double voltage, int frequency)
    {
        _availableProfiles.Add(profile);
        if (profile is not "")
        {
            _timings = timings;
            _voltage = voltage;
            _frequency = frequency;
        }

        return this;
    }

    public RamBuilder FormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RamBuilder DdrVersion(string ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public RamBuilder PowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _ramSize,
            _supportedFrequenciesAndVoltages,
            _availableProfiles,
            _formFactor,
            _ddrVersion,
            _powerConsumption);
    }
}