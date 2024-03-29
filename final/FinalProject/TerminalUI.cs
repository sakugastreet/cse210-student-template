using System;
using System.Collections.Generic;
using System.IO;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

static class TerminalUI
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

    public static bool GetStringYN(string prompt = "", bool initclear = true)
    {
        // This is to enable me to not have to create code over and over again to get
        // a int from the user. The range parameter should tell the user what range they
        // can/should use for the int we want to parse.

        string userInput;
        TerminalUI.SmoothPrintLine(prompt, clearBeforePrint: initclear);
        while (true)
        {
            userInput = Console.ReadLine();
            if (userInput.ToLower() == "yes")
            {
                return true;
            }
            else if (userInput.ToLower() == "no")
            {
                return false;
            }
            else
            {
                TerminalUI.SmoothPrintLine("""Please enter Yes or No""");
            }


        }

    }
    static public int RunIntMenu(List<string> menu, int max, int min = 0)
    {
        int UserChoice;
        do
        {
            DisplayMenu(menu);
            UserChoice = TerminalUI.GetInt(min, max, "Please Enter Your Choice", false);
        } while (UserChoice < min || UserChoice > max);


        return UserChoice;

    }
    static private void DisplayMenu(List<string> menu)
    
    {
        Console.Clear();
        foreach (string line in menu)
        {
            TerminalUI.SmoothPrintLine(line, 8, false);
        }


}

    public static List<string> ReadTXTFile(string fileName)
    {
        List<string> fileContent = new List<string>();

        try
        {
            // Get the current directory of the application
            string currentDirectory = Directory.GetCurrentDirectory();

            // Combine the directory and filename to get the full file path
            string filePath = Path.Combine(currentDirectory, fileName);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist.");
                return fileContent;
            }

            // Open the text file using a StreamReader
            using (StreamReader sr = new StreamReader(filePath))
            {
                // Read the entire file and add each line to the list
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    fileContent.Add(line);
                }
            }
        }
        catch (Exception e)
        {
            // Display any exceptions that occur during file processing
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        return fileContent;
    }
    public static void WriteTXTFile(List<string> list, string fileName)
    {
        try
        {
            // Get the current directory of the application
            string currentDirectory = Directory.GetCurrentDirectory();

            // Combine the directory and filename to get the full file path
            string filePath = Path.Combine(currentDirectory, fileName);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (string item in list)
                {
                    writer.WriteLine(item);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }
}


