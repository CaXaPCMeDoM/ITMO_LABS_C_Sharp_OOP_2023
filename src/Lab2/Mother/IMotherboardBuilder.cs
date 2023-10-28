using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Attributes;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mother;

public interface IMotherboardBuilder
{
    MotherboardBuilder HaveWiFiModule(bool haveWiFiModule);
    MotherboardBuilder Name(string name);
    MotherboardBuilder ProcessorSocket(string socket);

    MotherboardBuilder NumberOfPciExpressLanes(int lanes);

    MotherboardBuilder NumberOfSataPorts(int ports);

    MotherboardBuilder ChipsetSupportXmp(Xmp supportChipset);

    MotherboardBuilder ChipsetSupportedRamFrequency(Collection<Ram> frequency);
    MotherboardBuilder SupportedRamStandard(string standard);

    MotherboardBuilder NumberOfRamSlots(int slots);

    MotherboardBuilder FormFactor(string formFactor);
    MotherboardBuilder Bios(string biosType);

    MotherboardBuilder BiosVersion(string biosVersion);

    MotherboardBuilder BiosSupportedProcessors(Collection<Processor> processor);
    Mother.Motherboard Build();
}