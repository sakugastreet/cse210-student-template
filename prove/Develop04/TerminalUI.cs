using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

public static class TerminalUI
{
    //This class is to boost some functionality I want in my terminal and working within the console.
    //Mostly just for smooth writing to the terminal
    public static void SmoothPrintLine(string message, int miliseconds=15, bool clearBeforePrint = true)
    {
        if (clearBeforePrint)
        {
            Console.Clear();
        }

        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(miliseconds);
        }
        Console.Write("\n");
    }
    public static void SmoothPrint(string message, int miliseconds = 15, bool clearBeforePrint = true)
    {
        if (clearBeforePrint)
        {
            Console.Clear();
        }

        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(miliseconds);
        }
    }
    public static int GetInt(int rangeStart = 0, int rangeEnd = 100, string prompt = "", bool initclear = true)
    {
        // This is to enable me to not have to create code over and over again to get
        // a int from the user. The range parameter should tell the user what range they
        // can/should use for the int we want to parse.

        int parsedInt;
        TerminalUI.SmoothPrintLine(prompt, clearBeforePrint:initclear);
        while (true)
        {
            
            if (int.TryParse(Console.ReadLine(), out parsedInt))
            {
                if (parsedInt < rangeStart | parsedInt > rangeEnd)
                {
                    TerminalUI.SmoothPrintLine($"Please enter a whole number between {rangeStart} and {rangeEnd}.");
                }
                else
                {
                break;
                }
            }
            else
            {
                TerminalUI.SmoothPrintLine($"Please enter a whole number between {rangeStart} and {rangeEnd}.");
            }


        }

        return parsedInt;
    }
}

