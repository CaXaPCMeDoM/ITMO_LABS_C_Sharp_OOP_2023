using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility.Base;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.StrategyOfFileSystemMode;
using Itmo.ObjectOrientedProgramming.Lab4.Parse;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public static class CheckingTreeGoToParser
{
    private const string MessageForTest = "tree goto asf";
    private const string MessageForInit = "connect A:\\neverSayNever -m local";
    [Theory]
    [MemberData(nameof(TestData))]
    public static void Test(ICommand commandInput)
    {
        ICommand? command;
        var chairOfCommand = new ChairOfCommand();
        Request requestFirst = Parser.ParserRequest(MessageForInit);
        chairOfCommand.AssemblingTheChain(requestFirst);
        Request requesSecond = Parse.Parser.ParserRequest(MessageForTest);
        command = chairOfCommand.AssemblingTheChain(requesSecond);

        Assert.IsAssignableFrom<ICommand>(commandInput);
        Assert.IsAssignableFrom<ICommand>(command);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new NavigateToDirectoryCommand(new FileCommandLocal(), "up"),
        };
    }
}