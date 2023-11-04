using Itmo.ObjectOrientedProgramming.Lab2.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mother;

public class Motherboard
{
    public Motherboard(
        bool haveWiFiModule,
        string name,
        string processorSocket,
        int numberOfPciExpressLanes,
        int numberOfSataPorts,
        Chipset chipset,
        string supportedRamStandard,
        int numberOfRamSlots,
        string formFactor,
        Bios bios)
    {
        HaveWiFiModule = haveWiFiModule;
        Name = name;
        ProcessorSocket = processorSocket;
        NumberOfPciExpressLanes = numberOfPciExpressLanes;
        NumberOfSataPorts = numberOfSataPorts;
        Chipset = chipset;
        SupportedRamStandard = supportedRamStandard;
        NumberOfRamSlots = numberOfRamSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public bool HaveWiFiModule { get; private set; }
    public string Name { get; private set; }

    public string ProcessorSocket { get; private set; }
    public int NumberOfPciExpressLanes { get; private set; }
    public int NumberOfSataPorts { get; private set; }
    public Chipset Chipset { get; private set; }
    public string SupportedRamStandard { get; private set; }
    public int NumberOfRamSlots { get; private set; }
    public string FormFactor { get; private set; }
    public Bios Bios { get; private set; }
    public Motherboard Clone()
    {
        return new Motherboard(
            HaveWiFiModule,
            Name,
            ProcessorSocket,
            NumberOfPciExpressLanes,
            NumberOfSataPorts,
            Chipset,
            SupportedRamStandard,
            NumberOfRamSlots,
            FormFactor,
            Bios)
        {
            HaveWiFiModule = HaveWiFiModule,
            Name = Name,
            ProcessorSocket = ProcessorSocket,
            NumberOfPciExpressLanes = NumberOfPciExpressLanes,
            NumberOfSataPorts = NumberOfSataPorts,
            Chipset = Chipset,
            SupportedRamStandard = SupportedRamStandard,
            NumberOfRamSlots = NumberOfRamSlots,
            FormFactor = FormFactor,
            Bios = Bios,
        };
    }

    public MotherboardBuilder Debuilder()
    {
        return new MotherboardBuilder()
            .BiosType(Bios.BiosType)
            .BiosVersion(Bios.BiosVersion)
            .Name(Name)
            .FormFactor(FormFactor)
            .HaveWiFiModule(HaveWiFiModule)
            .ProcessorSocket(ProcessorSocket)
            .NumberOfPciExpressLanes(NumberOfPciExpressLanes)
            .NumberOfSataPorts(NumberOfSataPorts)
            .NumberOfRamSlots(NumberOfRamSlots)
            .ChipsetSupportXmp(Chipset.SupportXmp)
            .ChipsetSupportedRamFrequency(Chipset.SupportRamFrequencies)
            .SupportedRamStandard(SupportedRamStandard);
    }
}