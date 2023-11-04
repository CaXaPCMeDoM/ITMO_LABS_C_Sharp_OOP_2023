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
    private string _supportedRamStandard = string.Empty;
    private int _numberOfRamSlots;
    private string _formFactor = string.Empty;
    private string _biosType = string.Empty;
    private string _biosVersion = string.Empty;
    private Collection<Processor> _supportedProcessors = new Collection<Processor>();
    private Xmp? _supportXmp;
    private Collection<Ram> _ramFrequencies = new Collection<Ram>();

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
        _supportXmp = supportChipset;
        return this;
    }

    public MotherboardBuilder ChipsetSupportedRamFrequency(Collection<Ram> frequency)
    {
        _ramFrequencies = frequency;
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

    public MotherboardBuilder BiosType(string biosType)
    {
        _biosType = biosType;
        return this;
    }

    public MotherboardBuilder BiosVersion(string biosVersion)
    {
        _biosVersion = biosVersion;
        return this;
    }

    public MotherboardBuilder BiosSupportedProcessors(Collection<Processor> processor)
    {
        _supportedProcessors = processor;
        return this;
    }

    public Motherboard Build()
    {
        var chipset = new Chipset(_ramFrequencies, _supportXmp);
        var bios = new Bios(_biosType, _biosVersion, _supportedProcessors);
        return new Motherboard(
            _haveWiFiModule,
            _name,
            _processorSocket,
            _numberOfPciExpressLanes,
            _numberOfSataPorts,
            chipset,
            _supportedRamStandard,
            _numberOfRamSlots,
            _formFactor,
            bios);
    }
}