using Itmo.ObjectOrientedProgramming.Lab2.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mother;

public class Motherboard
{
    public Motherboard(
        bool haveWiFiModule,
        string? name,
        string? processorSocket,
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
        Chipset = new Chipset();
        Chipset = chipset;
        SupportedRamStandard = supportedRamStandard;
        NumberOfRamSlots = numberOfRamSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public bool HaveWiFiModule { get; set; }
    public string? Name { get; set; }

    public string? ProcessorSocket { get; set; }
    public int NumberOfPciExpressLanes { get; set; }
    public int NumberOfSataPorts { get; set; }
    public Chipset Chipset { get; set; }
    public string SupportedRamStandard { get; set; }
    public int NumberOfRamSlots { get; set; }
    public string FormFactor { get; set; }
    public Bios Bios { get; set; }
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
}