using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Attributes;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mother;
public class MotherboardBuilder : IMotherboardBuilder
{
    private bool _haveWiFiModule;
    private string _name = string.Empty;
    private string _processorSocket = string.Empty;
    private int _numberOfPciExpressLanes;
    private int _numberOfSataPorts;
    private Chipset _chipset = new Chipset();
    private string _supportedRamStandard = string.Empty;
    private int _numberOfRamSlots;
    private string _formFactor = string.Empty;
    private Bios _bios = new Bios();

    public MotherboardBuilder HaveWiFiModule(bool haveWiFiModule)
    {
        _haveWiFiModule = haveWiFiModule;
        return this;
    }

    public MotherboardBuilder Name(string name)
    {
        _name = name;
        return this;
    }

    public MotherboardBuilder ProcessorSocket(string socket)
    {
        _processorSocket = socket;
        return this;
    }

    public MotherboardBuilder NumberOfPciExpressLanes(int lanes)
    {
        _numberOfPciExpressLanes = lanes;
        return this;
    }

    public MotherboardBuilder NumberOfSataPorts(int ports)
    {
        _numberOfSataPorts = ports;
        return this;
    }

    public MotherboardBuilder ChipsetSupportXmp(Xmp? supportChipset)
    {
        _chipset.StateСhangeSupportXmp(supportChipset);
        return this;
    }

    public MotherboardBuilder ChipsetSupportedRamFrequency(Collection<Ram> frequency)
    {
        _chipset.AddSupportedRamFrequencies(frequency);
        return this;
    }

    public MotherboardBuilder SupportedRamStandard(string standard)
    {
        _supportedRamStandard = standard;
        return this;
    }

    public MotherboardBuilder NumberOfRamSlots(int slots)
    {
        _numberOfRamSlots = slots;
        return this;
    }

    public MotherboardBuilder FormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder Bios(string biosType)
    {
        _bios.BiosType = biosType;
        return this;
    }

    public MotherboardBuilder BiosVersion(string biosVersion)
    {
        _bios.BiosVersion = biosVersion;
        return this;
    }

    public MotherboardBuilder BiosSupportedProcessors(Collection<Processor> processor)
    {
        _bios.AddSupportedProcessors(processor);
        return this;
    }

    public Mother.Motherboard Build()
    {
        return new Motherboard(
            _haveWiFiModule,
            _name,
            _processorSocket,
            _numberOfPciExpressLanes,
            _numberOfSataPorts,
            _chipset,
            _supportedRamStandard,
            _numberOfRamSlots,
            _formFactor,
            _bios);
    }
}