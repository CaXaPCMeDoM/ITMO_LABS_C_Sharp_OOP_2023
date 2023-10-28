using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public class Ram
{
    public Ram(
        double ramSize,
        Collection<Tuple<int, double>> supportedFrequenciesAndVoltages,
        Collection<string> availableProfiles,
        string formFactor,
        string ddrVersion,
        double powerConsumption)
    {
        RamSize = ramSize;
        SupportedFrequenciesAndVoltages = supportedFrequenciesAndVoltages;
        AvailableProfiles = availableProfiles;
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public double RamSize { get; set; }
    public Collection<Tuple<int, double>> SupportedFrequenciesAndVoltages { get; init; }

    public Collection<string> AvailableProfiles { get; init; }
    public string FormFactor { get; set; }
    public string DdrVersion { get; set; }
    public double PowerConsumption { get; set; }

    public Ram Clone()
    {
        return new Ram(
            RamSize,
            SupportedFrequenciesAndVoltages,
            AvailableProfiles,
            FormFactor,
            DdrVersion,
            PowerConsumption)
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