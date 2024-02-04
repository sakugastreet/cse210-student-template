using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Xml.Serialization;



class Journal
{
    private string journalName;
    private string filePath;
    private List<Entry> entries;

    public Journal(string journalName, bool isNew=false)
    {
        this.journalName = journalName;
        filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{journalName}.txt");
        entries = new List<Entry>();
        if (isNew == false)
            this.LoadFromFile();
    }

    private void LoadFromFile()
    {
        string date = "";
        string text = "";
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] sublines = line.Split("|");

            if (sublines.Length == 1)
            {
                text += line;
            }
            else
            {
                if (!string.IsNullOrEmpty(date))
                {
                    Entry newEntry = new Entry(date, text);
                    entries.Add(newEntry);
                }

                date = sublines[0];
                text = sublines[1];
            }
        }

        // Add the last entry after the loop
        if (!string.IsNullOrEmpty(date))
        {
            Entry lastEntry = new Entry(date, text);
            entries.Add(lastEntry);
        }
    }

    public void SaveToFile()
    {
        string fileTXT = "";
        foreach (Entry entry in entries)
        {
            fileTXT += $"{entry.date}|{entry.text}";
        }
        File.WriteAllText(filePath, fileTXT);
    }

    public void PrintAllEntries()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }
    public void CreateEntry(string date, string text)
    {
        Entry newentry = new Entry(date, text);
        entries.Add(newentry);
    }
}

class Entry
{
    public string date;
    public string text;

    public Entry(string date, string text)
    {
        this.date = date;
        this.text = text;
    }

    public void Display()
    {
        Console.WriteLine($"Entry from {date}:\n{text}");
    }
}


class UI
{
    private static int userChoice;
    private List<string> journalNames = new List<string> {};
    private List<Journal> journals = new List<Journal> {};
    static Random random = new Random();


    static List<string> mainMenu = new List<string> {"Main Menu:", "1: New Journal", "2: Load Journal", "3 See all Journals", "0: Quit"};
    static List<string> journalMenu = new List<string> {"Journal Menu:", "1: Preview all Entries", "2: Enter New Entry", "3: Get prompt", "0: Quit"};

    
    public UI()
    {
        LoadJournals();
        Main();
    }

    private void Main()
    {
        do 
        {
            DisplayMenu(mainMenu);
            userChoice = GetUserInput();
            if (userChoice != 0)
            {
                DoTask(userChoice);
                userChoice = -1;
            }
        } while (userChoice != 0);


        Console.WriteLine("Thanks for using this program, Have a nice day");
        SaveJournals();
    }

    static void DisplayMenu(List<string> list)
    {
        foreach (string line in list)
        {
            Console.WriteLine(line);
        }
        
    }
    private void DoTask(int userChoice)
    {
        if (userChoice == 1)
        {
            NewJournal();
        }
        else if (userChoice == 2)
        {
            if (journals.Count() != 0)
            {
                UseJournal();
            }
        }
        else if (userChoice == 3)
        {
            if (journalNames.Count() >= 1)
            {
                Console.WriteLine("Here are all the Journals we have access to");
                foreach (string name in journalNames)
                {
                    Console.WriteLine(name);
                }
            }
            else
            {
                Console.WriteLine("There are no journals in our archives");
            }
            Console.WriteLine("\n");
        }
        else if (userChoice == 4)
        {

        }
    }
    static int GetUserInput()
    {
        do
        {
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out userChoice))
            {
                Console.WriteLine("\n");

                if (userChoice > 3)
                {
                    Console.WriteLine("Invalid input. Please enter an integer between 1-3.");
                    userChoice = -1;
                }
                else if (userChoice < 0)
                {
                    Console.WriteLine("Invalid input. Please enter an integer between 1-3.");
                    userChoice = -1;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer between 1-3.");
                userChoice = -1;
            }
        } while (userChoice == -1);
        return userChoice;
    }
    private bool LoadJournals()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "JournalNames.txt");
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            // Process the lines as needed
            foreach (string line in lines)
            {
                journalNames.Add(line);
                Journal newJournal = new Journal(line);
                journals.Add(newJournal);
            }
            return true;
        }
        catch (FileNotFoundException)
        {
            return false;
        }
        catch (DirectoryNotFoundException)
        {
            return false;
        }
        catch (IOException)
        {
            return false;
        }

    }
    private void SaveJournals()
    {
        foreach (Journal journal in journals)
        {
            journal.SaveToFile();
        }
        string journalTXT = "";
        foreach (string name in journalNames)
        {
            journalTXT += name + "\n";
        }
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "JournalNames.txt");
        File.WriteAllText(filePath, journalTXT);
    }
    private void NewJournal()
    {
        bool nameInvalid;
        string newJournalName;
        do
        {
            Console.WriteLine("What would you like to name your new journal? ");
            newJournalName = Console.ReadLine();
            if (journalNames.Contains(newJournalName))
            {
                Console.WriteLine("That journal name is already being used, please choose another.");
                nameInvalid = true;
            } 
            else{
                nameInvalid = false;
            }
        } while (nameInvalid);

        Journal newJournal = new Journal(newJournalName, true);
        journalNames.Add(newJournalName);
        journals.Add(newJournal);
        Console.WriteLine("");
        Console.WriteLine($"A new journal has been created named {newJournalName}. \n");
    }

    private void UseJournal()
    {
        int jUserChoice;
        bool nameValid;
        Journal activeJournal;
        string userInput;
        // get a valid journal name
        do
        {
            Console.WriteLine("What is the name of the Journal would you like to open");
            userInput = Console.ReadLine();
            if (journalNames.Contains(userInput))
            {
                nameValid = true;
            }
            else
            {
                Console.WriteLine("Invalid Journal Name. Please try again. \n");
                nameValid = false;
            }
        } while (nameValid == false);


        activeJournal = journals.ElementAt(journalNames.IndexOf(userInput));
        // loop for using journal
        do
        {
            DisplayMenu(journalMenu);
            jUserChoice = GetUserInput();
            if (jUserChoice != 0)
            {
                DoJournalTask(jUserChoice, activeJournal);
            }
        } while (jUserChoice != 0);
    }
    private void DoJournalTask(int juserChoice, Journal activeJournal)
    {
        if (juserChoice == 1)
        {
            activeJournal.PrintAllEntries();
        }
        else if (juserChoice == 2)
        {
            Console.WriteLine("What date do you want to be associated with this entry?" );
            string date = Console.ReadLine();

            string text = "";
            string newText;
            Console.Write("""Please Write your Entry. When completed please enter a new line with the characters "---" """);
            do
            {
                newText = Console.ReadLine();
                if (newText != "---")
                {
                    text += newText;
                }
            } while (newText != "---");

            activeJournal.CreateEntry(date, text);
        }
        else if (juserChoice == 3)
        {
            {
                int randomInt = random.Next(PromptGenerator.prompts.Count);
                Console.WriteLine(PromptGenerator.prompts.ElementAt(randomInt));
            }
    }
}
}
static class PromptGenerator
{
    public static List<string> prompts = new List<string>
    {
        "Describe a memorable moment from today.",
        "Reflect on a challenge you faced and how you overcame it.",
        "Write about something that made you smile today.",
        "What are you grateful for right now?",
        "Explore a goal or aspiration you have for the future.",
        "Share your thoughts on a book, movie, or song that moved you recently.",
        "Write a letter to your future self.",
        "Reflect on a lesson you learned recently.",
        "Describe a place that holds special meaning for you.",
        "Write about a hobby or activity that brings you joy.",
        "Reflect on the people who inspire you and why.",
        "Explore a dream you had recently.",
        "Write about a moment when you felt proud of yourself.",
        "Describe a quiet moment of reflection you had today.",
        "What is a positive habit you want to cultivate?",
        "Reflect on a mistake and the lessons learned from it.",
        "Write about a random act of kindness you witnessed or experienced.",
        "Share your thoughts on a current event or social issue.",
        "Describe the beauty of nature you observed today.",
        "What is something you would like to improve about yourself?"
    };
}


class Program
{
    static void Main()
    {
        UI lilUI = new UI();
    }
}