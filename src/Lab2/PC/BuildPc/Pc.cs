using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Mother;
using Itmo.ObjectOrientedProgramming.Lab2.Power;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.BuildPc;

public class Pc
{
    public Pc(ResultsProcessingOfPcComponents result, Motherboard? motherboard, Processor? processor, ProcessorCoolingSystem? processorCoolingSystem, ICollection<Ram>? ram, ICollection<Gpu>? gpu, ICollection<Ssd>? ssd, ICollection<Hdd>? hdd, ComputerCase? computerCase, PowerUnit? powerUnit, WiFiAdapter? wiFiAdapter)
    {
        Result = result;
        Motherboard = motherboard;
        Processor = processor;
        ProcessorCoolingSystem = processorCoolingSystem;
        Ram = ram;
        Gpu = gpu;
        Ssd = ssd;
        Hdd = hdd;
        ComputerCase = computerCase;
        PowerUnit = powerUnit;
        WiFiAdapter = wiFiAdapter;
    }

    public ResultsProcessingOfPcComponents Result { get; private set; }
    public Mother.Motherboard? Motherboard { get; private set; }
    public Processor? Processor { get; private set; }

    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; private set; }

    public ICollection<Ram>? Ram { get; }
    public ICollection<Gpu>? Gpu { get; }
    public ICollection<Ssd>? Ssd { get; }
    public ICollection<Hdd>? Hdd { get; }
    public ComputerCase? ComputerCase { get; private set; }
    public Power.PowerUnit? PowerUnit { get; private set; }
    public WiFiAdapter? WiFiAdapter { get; private set; }
}