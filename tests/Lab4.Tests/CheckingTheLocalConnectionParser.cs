using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public static class CheckingTheLocalConnectionParser
{
    private const string MessageForTest = "connect A:\\andWhat -m local";
    private const string MessageForTestData = "A:\\dontDeleteMySystem";
    [Theory]
    [MemberData(nameof(TestData))]
    public static void Test(ICommand commandInput)
    {
        ICommand? command;
        var chairOfCommand = new ChairOfCommand();
        Request request = Parse.Parser.ParserRequest(MessageForTest);
        command = chairOfCommand.AssemblingTheChain(request);

        Assert.IsAssignableFrom<ICommand>(commandInput);
        Assert.IsAssignableFrom<ICommand>(command);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new ConnectCommand(new FileCommandLocal(), MessageForTestData),
        };
    }
}