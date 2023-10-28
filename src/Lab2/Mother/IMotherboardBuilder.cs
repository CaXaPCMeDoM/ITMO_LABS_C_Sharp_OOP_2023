using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mother;

public interface IMotherboardBuilder
{
    MotherboardBuilder HaveWiFiModule(bool haveWiFiModule);
    MotherboardBuilder Name(string name);
    MotherboardBuilder ProcessorSocket(string socket);

    MotherboardBuilder NumberOfPciExpressLanes(int lanes);

    MotherboardBuilder NumberOfSataPorts(int ports);

    MotherboardBuilder ChipsetSupportXmp(bool supportChipset);

    MotherboardBuilder ChipsetSupportedRamFrequency(Collection<string> frequency);
    MotherboardBuilder SupportedRamStandard(string standard);

    MotherboardBuilder NumberOfRamSlots(int slots);

    MotherboardBuilder FormFactor(string formFactor);
    MotherboardBuilder Bios(string biosType);

    MotherboardBuilder BiosVersion(string biosVersion);

    MotherboardBuilder BiosSupportedProcessors(Collection<string> processor);
    Mother.Motherboard Build();
}