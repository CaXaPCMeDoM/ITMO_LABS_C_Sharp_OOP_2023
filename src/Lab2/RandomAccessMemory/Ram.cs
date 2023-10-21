using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public class Ram
{
    public double RamSize { get; set; }
    public Collection<Tuple<int, double>> SupportedFrequenciesAndVoltages { get; init; } = new();

    public Collection<string> AvailableProfiles { get; init; } = new();
    public string FormFactor { get; set; } = string.Empty;
    public string DdrVersion { get; set; } = string.Empty;
    public double PowerConsumption { get; set; }

    public Ram Clone()
    {
        return new Ram()
        {
            RamSize = RamSize,
            PowerConsumption = PowerConsumption,
            SupportedFrequenciesAndVoltages = SupportedFrequenciesAndVoltages,
            AvailableProfiles = AvailableProfiles,
            FormFactor = FormFactor,
            DdrVersion = DdrVersion,
        };
    }
}