using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.COMPUTERCASE;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.HardDiskDrive;
using Itmo.ObjectOrientedProgramming.Lab2.DataStorage.SolidStateDisk;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Mother;
using Itmo.ObjectOrientedProgramming.Lab2.PC.BuildPc;
using Itmo.ObjectOrientedProgramming.Lab2.Power;
using Itmo.ObjectOrientedProgramming.Lab2.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.RandomAccessMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Repository.InMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Sales;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public static class Main
{
    [Theory]
    [MemberData(nameof(TestFirstData))]
    public static void TestFirst(ResultsProcessingOfPcComponents resultFirst)
    {
        Mother.Motherboard motherboard = new MotherBoardInMemoryRepository().ReadOnlyCollection[0];
        Gpu gpu = new GpuInMemoryRepository().ReadOnlyCollection[0];
        Processor processor = new CpuInMemoryRepository().ReadOnlyCollection[0];
        ProcessorCoolingSystem processorCoolingSystem = new ProcessorCoolingInMemoryRepository().ReadOnlyCollection[0];
        Ram ram = new RamInMemoryRepository().ReadOnlyCollection[0];
        Ssd ssd = new SsdInMemoryRepository().ReadOnlyCollection[0];
        Hdd hdd = new HddInMemoryRepository().ReadOnlyCollection[0];
        ComputerCase computerCase = new CaseInMemoryRepository().ReadOnlyCollection[0];
        PowerUnit powerUnit = new PowerUnitInMemoryRepository().ReadOnlyCollection[0];

        Pc pc;
        pc = new PcBuild()
            .GpuBuilder(gpu)
            .MotherboardBuilder(motherboard)
            .ProcessorBuilder(processor)
            .ProcessorCoolingSystemBuilder(processorCoolingSystem)
            .RamBuilder(ram)
            .SsdBuilder(ssd)
            .HddBuilder(hdd)
            .ComputerCaseBuilder(computerCase)
            .PowerUnitBuilder(powerUnit)
            .Build();
        Assert.Equal(resultFirst, pc.Result);
    }

    public static IEnumerable<object[]> TestFirstData()
    {
        yield return new object[]
            {
                ResultsProcessingOfPcComponents.Successful,
            };
    }

    [Theory]
    [MemberData(nameof(TestSecondData))]
    public static void TestSecond(ResultsProcessingOfPcComponents resultFirst)
    {
        Mother.Motherboard motherboard = new MotherBoardInMemoryRepository().ReadOnlyCollection[0];
        Gpu gpu = new GpuInMemoryRepository().ReadOnlyCollection[0];
        Processor processor = new CpuInMemoryRepository().ReadOnlyCollection[0];
        ProcessorCoolingSystem processorCoolingSystem = new ProcessorCoolingInMemoryRepository().ReadOnlyCollection[0];
        Ram ram = new RamInMemoryRepository().ReadOnlyCollection[0];
        Ssd ssd = new SsdInMemoryRepository().ReadOnlyCollection[0];
        Hdd hdd = new HddInMemoryRepository().ReadOnlyCollection[0];
        ComputerCase computerCase = new CaseInMemoryRepository().ReadOnlyCollection[0];
        PowerUnit powerUnit = new PowerUnitInMemoryRepository().ReadOnlyCollection[1];

        Pc pc;
        pc = new PcBuild()
            .GpuBuilder(gpu)
            .MotherboardBuilder(motherboard)
            .ProcessorBuilder(processor)
            .ProcessorCoolingSystemBuilder(processorCoolingSystem)
            .RamBuilder(ram)
            .SsdBuilder(ssd)
            .HddBuilder(hdd)
            .ComputerCaseBuilder(computerCase)
            .PowerUnitBuilder(powerUnit)
            .Build();
        Assert.Equal(resultFirst, pc.Result);
    }

    public static IEnumerable<object[]> TestSecondData()
    {
        yield return new object[]
        {
            ResultsProcessingOfPcComponents.Warning,
        };
    }

    [Theory]
    [MemberData(nameof(TestThirdData))]
    public static void TestThird(ResultsProcessingOfPcComponents resultFirst)
    {
        Mother.Motherboard motherboard = new MotherBoardInMemoryRepository().ReadOnlyCollection[0];
        Gpu gpu = new GpuInMemoryRepository().ReadOnlyCollection[0];
        Processor processor = new CpuInMemoryRepository().ReadOnlyCollection[0];
        ProcessorCoolingSystem processorCoolingSystem = new ProcessorCoolingInMemoryRepository().ReadOnlyCollection[1];
        Ram ram = new RamInMemoryRepository().ReadOnlyCollection[0];
        Ssd ssd = new SsdInMemoryRepository().ReadOnlyCollection[0];
        Hdd hdd = new HddInMemoryRepository().ReadOnlyCollection[0];
        ComputerCase computerCase = new CaseInMemoryRepository().ReadOnlyCollection[0];
        PowerUnit powerUnit = new PowerUnitInMemoryRepository().ReadOnlyCollection[0];

        Pc pc;
        pc = new PcBuild()
            .GpuBuilder(gpu)
            .MotherboardBuilder(motherboard)
            .ProcessorBuilder(processor)
            .ProcessorCoolingSystemBuilder(processorCoolingSystem)
            .RamBuilder(ram)
            .SsdBuilder(ssd)
            .HddBuilder(hdd)
            .ComputerCaseBuilder(computerCase)
            .PowerUnitBuilder(powerUnit)
            .Build();
        Assert.Equal(resultFirst, pc.Result);
        Assert.Equal(resultFirst, MessageToTheSalesDepartment.Send(pc.Result));
    }

    public static IEnumerable<object[]> TestThirdData()
    {
        yield return new object[]
        {
            ResultsProcessingOfPcComponents.Warning,
        };
    }

    [Theory]
    [MemberData(nameof(TestFourthData))]
    public static void TestFourth(ResultsProcessingOfPcComponents resultFirst, ResultsProcessingOfPcComponents resultSecond, ResultsProcessingOfPcComponents resultThird)
    {
        Mother.Motherboard motherboard = new MotherBoardInMemoryRepository().ReadOnlyCollection[0];
        Gpu gpu = new GpuInMemoryRepository().ReadOnlyCollection[0];
        Processor processor = new CpuInMemoryRepository().ReadOnlyCollection[0];
        ProcessorCoolingSystem processorCoolingSystem = new ProcessorCoolingInMemoryRepository().ReadOnlyCollection[1];
        Ram ram = new RamInMemoryRepository().ReadOnlyCollection[0];
        Ssd ssd = new SsdInMemoryRepository().ReadOnlyCollection[0];
        Hdd hdd = new HddInMemoryRepository().ReadOnlyCollection[0];
        ComputerCase computerCase = new CaseInMemoryRepository().ReadOnlyCollection[0];
        PowerUnit powerUnit = new PowerUnitInMemoryRepository().ReadOnlyCollection[0];

        Pc pcFirst = new PcBuild()
            .GpuBuilder(gpu)
            .MotherboardBuilder(motherboard)
            .ProcessorBuilder(processor)
            .ProcessorCoolingSystemBuilder(processorCoolingSystem)
            .RamBuilder(ram)
            .SsdBuilder(ssd)
            .HddBuilder(hdd)
            .ComputerCaseBuilder(computerCase)
            .PowerUnitBuilder(powerUnit)
            .Build();
        ProcessorCoolingSystem newProcessorCoolingSystem = processorCoolingSystem.Clone();
        newProcessorCoolingSystem.Tdp = 100;
        Pc pcSecond = new PcBuild()
            .GpuBuilder(gpu)
            .MotherboardBuilder(motherboard)
            .ProcessorBuilder(processor)
            .ProcessorCoolingSystemBuilder(newProcessorCoolingSystem)
            .RamBuilder(ram)
            .SsdBuilder(ssd)
            .HddBuilder(hdd)
            .ComputerCaseBuilder(computerCase)
            .PowerUnitBuilder(powerUnit)
            .Build();
        Motherboard newMotherboard = motherboard.Clone();
        newMotherboard.NumberOfPciExpressLanes = 3;
        Pc pcThird = new PcBuild()
            .GpuBuilder(gpu)
            .MotherboardBuilder(newMotherboard)
            .GpuBuilder(gpu)
            .GpuBuilder(gpu)
            .GpuBuilder(gpu)
            .ProcessorBuilder(processor)
            .ProcessorCoolingSystemBuilder(newProcessorCoolingSystem)
            .RamBuilder(ram)
            .SsdBuilder(ssd)
            .HddBuilder(hdd)
            .ComputerCaseBuilder(computerCase)
            .PowerUnitBuilder(powerUnit)
            .Build();
        Assert.Equal(resultFirst, pcFirst.Result);
        Assert.Equal(resultSecond, pcSecond.Result);
        Assert.Equal(resultThird, pcThird.Result);
    }

    public static IEnumerable<object[]> TestFourthData()
    {
        yield return new object[]
        {
            ResultsProcessingOfPcComponents.Warning, ResultsProcessingOfPcComponents.Successful, ResultsProcessingOfPcComponents.PcieCountError,
        };
    }
}