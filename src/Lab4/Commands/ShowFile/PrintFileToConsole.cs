using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ShowFile;

public class PrintFileToConsole : IPrintFile
{
    public void PrintFile(string fileString)
    {
        Console.WriteLine(fileString);
    }
}