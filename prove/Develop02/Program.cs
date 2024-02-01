// using System;
// using System.Reflection.Metadata;
// using System.Text.Json.Serialization;
// using Microsoft.VisualBasic;

// class Journal
// {
//     //inits list of Entries and Name

//     public string journalName;
//     public string filePath;
//     public List<Entry> entries;

//     public Journal(string journalName)
//     {
//         this.journalName = journalName;
//         filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{journalName}.txt");
//         this.LoadFromFile();
//         this.printAllEntries();

//     }
//     public void LoadFromFile()
//     {
//         string date = "";
//         string text = "";
//         string[] lines = File.ReadAllLines(filePath);
//         List<Entry> Entries = new List<Entry>();
//         foreach (string line in lines)
//         {

//             string[] sublines = line.Split("|");
//             if (sublines.Length == 1)
//             {
//                 text += line;
//             }
//             else
//             {
//                 Entry newEntry = new Entry(date, text);
//                 entries.Add(newEntry);
//                 date = sublines[0];
//                 text = sublines[1];

//             }



//         }

//     }


//     static void saveToFile(string filename)
//     {

//     }
//     public void printAllEntries()
//     {
//         foreach (Entry entry in entries)
//         {
//             entry.display();
//         }
//     }



// }

// class Entry
// {
//     public string date;
//     public string text;

//     public Entry(string date, string text)
//     {
//         this.date = date;
//         this.text = text;
//     }
//     public void display()
//     {
//         Console.WriteLine($"""entry from {date}:\n{text}""");
//     }

// }



// class Program
// {
//     static void Main()
//     {


//         Journal jimmie = new Journal("blah");

//         // string currentDirectory = Directory.GetCurrentDirectory();
//         // string filePath = Path.Combine(currentDirectory, "blah.txt");
//         // string[] lines = File.ReadAllLines(filePath);


//         // foreach (string line in lines)
//         // {
//         //     Console.WriteLine(line);
//         // }
//         // Console.WriteLine(Directory.GetCurrentDirectory());
//     }
// }

using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public string journalName;
    public string filePath;
    public List<Entry> entries;

    public Journal(string journalName)
    {
        this.journalName = journalName;
        filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{journalName}.txt");
        entries = new List<Entry>(); // Initialize the list of entries
        this.LoadFromFile();
        this.PrintAllEntries();
    }

    public void LoadFromFile()
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
        // Implement code to save entries to the file
    }

    public void PrintAllEntries()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
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

class Program
{
    static void Main()
    {
        Journal jimmie = new Journal("blah");
    }
}
