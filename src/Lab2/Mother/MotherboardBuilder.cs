using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mother;
public class MotherboardBuilder : IMotherboardBuilder
{
    internal MotherboardBuilder()
    {
        Motherboard = new Motherboard();
    }

    private Motherboard Motherboard { get; set; }

    public MotherboardBuilder HaveWiFiModule(bool haveWiFiModule)
    {
        Motherboard.HaveWiFiModule = haveWiFiModule;
        return this;
    }

    public MotherboardBuilder Name(string name)
    {
        Motherboard.Name = name;
        return this;
    }

    public MotherboardBuilder ProcessorSocket(string socket)
    {
        Motherboard.ProcessorSocket = socket;
        return this;
    }

    public MotherboardBuilder NumberOfPciExpressLanes(int lanes)
    {
        Motherboard.NumberOfPciExpressLanes = lanes;
        return this;
    }

    public MotherboardBuilder NumberOfSataPorts(int ports)
    {
        Motherboard.NumberOfSataPorts = ports;
        return this;
    }

    public MotherboardBuilder ChipsetSupportXmp(bool supportChipset)
    {
        Motherboard.Chipset.StateСhangeSupportXmp(supportChipset);
        return this;
    }

    public MotherboardBuilder ChipsetSupportedRamFrequency(Collection<string> frequency)
    {
        Motherboard.Chipset.AddSupportedRamFrequencies(frequency);
        return this;
    }

    public MotherboardBuilder SupportedRamStandard(string standard)
    {
        Motherboard.SupportedRamStandard = standard;
        return this;
    }

    public MotherboardBuilder NumberOfRamSlots(int slots)
    {
        Motherboard.NumberOfRamSlots = slots;
        return this;
    }

    public MotherboardBuilder FormFactor(string formFactor)
    {
        Motherboard.FormFactor = formFactor;
        return this;
    }

    public MotherboardBuilder Bios(string biosType)
    {
        Motherboard.Bios.BiosType = biosType;
        return this;
    }

    public MotherboardBuilder BiosVersion(string biosVersion)
    {
        Motherboard.Bios.BiosVersion = biosVersion;
        return this;
    }

    public MotherboardBuilder BiosSupportedProcessors(Collection<string> processor)
    {
        Motherboard.Bios.AddSupportedProcessors(processor);
        return this;
    }

    public Mother.Motherboard Build()
    {
        return Motherboard;
    }
}