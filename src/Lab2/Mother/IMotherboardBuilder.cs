using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Attributes;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mother;

public interface IMotherboardBuilder
{
    protected MotherboardBuilder HaveWiFiModule(bool haveWiFiModule);
    protected MotherboardBuilder Name(string name);
    protected MotherboardBuilder ProcessorSocket(string socket);

    protected MotherboardBuilder NumberOfPciExpressLanes(int lanes);

    protected MotherboardBuilder NumberOfSataPorts(int ports);

    protected MotherboardBuilder ChipsetSupportXmp(Xmp supportChipset);

    protected MotherboardBuilder ChipsetSupportedRamFrequency(Collection<Ram> frequency);
    protected MotherboardBuilder SupportedRamStandard(string standard);

    protected MotherboardBuilder NumberOfRamSlots(int slots);

    protected MotherboardBuilder FormFactor(string formFactor);
    protected MotherboardBuilder BiosType(string biosType);

    protected MotherboardBuilder BiosVersion(string biosVersion);

    protected MotherboardBuilder BiosSupportedProcessors(Collection<Processor> processor);
    protected Motherboard Build();
}