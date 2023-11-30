using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainOfResponsibility;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parse;

public static class Parser
{
    public static Request ParserRequest(string input)
    {
        string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var parameters = new List<string>();

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].StartsWith("-", StringComparison.CurrentCulture))
            {
                parameters.Add(parts[i]);
                if (i + 1 < parts.Length && !parts[i + 1].StartsWith("-", StringComparison.CurrentCulture))
                {
                    parameters.Add(parts[i + 1]);
                    i++;
                }
            }
            else
            {
                parameters.Add(parts[i]);
            }
        }

        return new Request(parameters);
    }

    public static string ParserFlagInRequest(Request request, string consoleFlag)
    {
        bool weAreFindFlag = false;
        string modeFullStringInSend = string.Empty;
        foreach (string substring in request.Arguments)
        {
            if (substring == consoleFlag)
            {
                weAreFindFlag = true;
                continue;
            }

            if (weAreFindFlag == true)
            {
                modeFullStringInSend += substring;
            }
        }

        return modeFullStringInSend;
    }
}