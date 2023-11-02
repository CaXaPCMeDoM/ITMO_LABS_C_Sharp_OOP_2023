using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public class RamBuilder : IRamBuilder
{
    private const int _emptyVariable = 0;
    private double _ramSize = _emptyVariable;
    private Collection<int> _supportedFrequencies = new();
    private Collection<double> _supportedVoltage = new();
    private Collection<string> _availableProfiles = new();
    private string _formFactor = string.Empty;
    private string _ddrVersion = string.Empty;
    private double _powerConsumption = _emptyVariable;
    private double _timings = _emptyVariable;
    private double _voltage = _emptyVariable;
    private int _frequency = _emptyVariable;

    public RamBuilder RamSize(double ramSize)
    {
        _ramSize = ramSize;
        return this;
    }

    public RamBuilder SupportedFrequency(Collection<int> frequency)
    {
        _supportedFrequencies = frequency;
        return this;
    }

    public RamBuilder SupportedVoltage(Collection<double> voltage)
    {
        _supportedVoltage = voltage;
        return this;
    }

    public RamBuilder AvailableProfile(Collection<string> profile)
    {
        _availableProfiles = profile;
        return this;
    }

    public RamBuilder AvailableTimings(double timings)
    {
        _timings = timings;
        return this;
    }

    public RamBuilder AvailableVoltage(double voltage)
    {
        _voltage = voltage;
        return this;
    }

    public RamBuilder AvailableFrequency(int frequency)
    {
        _frequency = frequency;
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
        if (_ramSize == _emptyVariable ||
            _supportedFrequencies.Count == _emptyVariable ||
            _supportedVoltage.Count == _emptyVariable ||
            _formFactor.Length == _emptyVariable ||
            _ddrVersion.Length == _emptyVariable ||
            _powerConsumption == _emptyVariable)
        {
            throw new EmptyValuesException();
        }

        return new Ram(
            _ramSize,
            _supportedFrequencies,
            _supportedVoltage,
            _availableProfiles,
            _formFactor,
            _ddrVersion,
            _powerConsumption);
    }
}