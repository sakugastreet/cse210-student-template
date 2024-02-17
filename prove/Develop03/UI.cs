using System;
using System.Collections.Generic;



public class UI
{
    List<string> menu = new List<string> 
    {
        "Which Scripture would you like to work on?"
    };
    List<string> writingRefs = Library.writingRefs;
    List<string> writings = Library.writings;

    
    public void Main()
    {
        string userinput;
        int userOption;

        // sets up menu based on how many scriptures are in the library
        int indicator = 1;
        foreach (string writing in writingRefs)
        {
            menu.Add($"{indicator}: {writing}");
            indicator++;
        }
        menu.Add("0: Quit");


        Console.WriteLine("Welcome! What would you like to do today?");
        do
        {
            DisplayMenu();
            userinput = Console.ReadLine();
            if (int.TryParse(userinput, out userOption))
            {
                if (userOption is >= 1 and <= 4)
                {
                    LoadScripture(userOption);
                }
                else if (userOption == 0)
                {
                    Console.WriteLine("Thank you for your time.\n\n");
                }

                else
                {
                    Console.WriteLine($"please enter a digit between 1 and 5, not {userOption}");
                }
            }
            else
            {
                Console.WriteLine("Please enter a correct digit");
                userOption = -1;
            }


        } while (userOption != 0);
    }

    

    public void DisplayMenu()
    {
        foreach (string line in menu)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine("Please enter your desicion below");
    }

    public void LoadScripture(int userOption)
    {
        Scripture newScripture = new Scripture(writings[userOption - 1]);
        bool completed = false;
        do
        {
            newScripture.Display();
            Console.WriteLine("\n --Press Enter To Continue--"); 
            Console.ReadLine();
            if (newScripture.isAllWordsHidden == true)
            {
                completed = true;
            }
            else
            {
                newScripture.HideMoreWords(3);
            }
         
        } while (completed == false);

        Console.Write("\n\n Back to Menu \n\n");
    }
}