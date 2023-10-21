using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mother;

public interface IMotherboardBuilder
{
    public MotherboardBuilder HaveWiFiModule(bool haveWiFiModule);
    public MotherboardBuilder Name(string name);
    public MotherboardBuilder ProcessorSocket(string socket);

    public MotherboardBuilder NumberOfPciExpressLanes(int lanes);

    public MotherboardBuilder NumberOfSataPorts(int ports);

    public MotherboardBuilder ChipsetSupportXmp(bool supportChipset);

    public MotherboardBuilder ChipsetSupportedRamFrequency(Collection<string> frequency);
    public MotherboardBuilder SupportedRamStandard(string standard);

    public MotherboardBuilder NumberOfRamSlots(int slots);

    public MotherboardBuilder FormFactor(string formFactor);
    public MotherboardBuilder Bios(string biosType);

    public MotherboardBuilder BiosVersion(string biosVersion);

    public MotherboardBuilder BiosSupportedProcessors(Collection<string> processor);
    public Mother.Motherboard Build();
}