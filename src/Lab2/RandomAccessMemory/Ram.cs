using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

public class Ram
{
    public Ram(
        double ramSize,
        Collection<int> supportedFrequencies,
        Collection<double> supportedVoltages,
        Collection<string> availableProfiles,
        string formFactor,
        string ddrVersion,
        double powerConsumption)
    {
        RamSize = ramSize;
        SupportedVoltages = supportedVoltages;
        AvailableProfiles = availableProfiles;
        SupportedFrequencies = supportedFrequencies;
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public double RamSize { get; private set; }
    public Collection<int> SupportedFrequencies { get; private set; }
    public Collection<double> SupportedVoltages { get; private set; }

    public Collection<string> AvailableProfiles { get; private set; }
    public string FormFactor { get; private set; }
    public string DdrVersion { get; private set; }
    public double PowerConsumption { get; private set; }

    public Ram Clone()
    {
        return new Ram(
            RamSize,
            SupportedFrequencies,
            SupportedVoltages,
            AvailableProfiles,
            FormFactor,
            DdrVersion,
            PowerConsumption)
        {
            RamSize = RamSize,
            PowerConsumption = PowerConsumption,
            SupportedVoltages = SupportedVoltages,
            SupportedFrequencies = SupportedFrequencies,
            AvailableProfiles = AvailableProfiles,
            FormFactor = FormFactor,
            DdrVersion = DdrVersion,
        };
    }

    public RamBuilder Debuilder()
    {
        return new RamBuilder()
            .RamSize(RamSize)
            .SupportedFrequency(SupportedFrequencies)
            .SupportedVoltage(SupportedVoltages)
            .PowerConsumption(PowerConsumption)
            .AvailableProfile(AvailableProfiles)
            .FormFactor(FormFactor)
            .DdrVersion(DdrVersion);
    }
}