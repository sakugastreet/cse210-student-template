using System;
using System.Drawing;
using System.Text.Json;

class User
{
    public string Name { get; set; }
    public List<Goal> Goals { get; set; }
    public int Points { get; set; }
    private List<string> mainMenu = new List<string> {
        "1 - View Goals",
        "2 - Add goal",
        "3 - Remove Goal",
        "4 - Update Goal",
        "",
        "0 - Quit"
    };
    private List<string> GoalOptionsMenu = new List<string> {
        "What kind of goal would you like to add?",
        "1 - Eternal Goal",
        "2 - Checklist Goal",
        "3 - Simple Goal",
        "",
        "0 - Quit"
    };


    public User()
    {
        mainMenu.Insert(0, $"Welcome {Name}");
        mainMenu.Insert(1, $"Score: {Points}");
    }

    // public User(string name, int points=0)
    // {
    //     mainMenu.Insert(0, $"Welcome {name}");
    //     mainMenu.Insert(1, $"Score: {points}");
    //     Goals = new List<Goal> {};
    //     Name = name;
    //     Points = points;

    // }

    public void Main()
    {
        int userChoice;
        do
        {
            userChoice = TerminalUI.RunIntMenu(mainMenu, 3);
            //display Goals
            if (userChoice == 1)
            {
                if (Goals.Count == 0)
                {
                    TerminalUI.SmoothPrintLine("No goals found with this user.");
                }
                else
                {
                    foreach (Goal goal in Goals)
                    {
                        goal.Display();
                    }
                }
            }
            else if (userChoice == 2)
            {
                AddGoal();
            }
            else if (userChoice == 3)
            {
                if (Goals.Count() == 0)
                {
                    TerminalUI.SmoothPrintLine("There are no goals with this user to remove");
                }
                else
                {
                    RemoveGoal();
                }
            }
            else if (userChoice == 4)
            {
                UpdateGoal();
            }

        } while (userChoice != 0);
    }

    public string SerializeUser()
    {
        return JsonSerializer.Serialize(this);
    }

    public void AddGoal()
    {
        TerminalUI.SmoothPrintLine("What do you want the name of your goal to be?");
        string goalName = Console.ReadLine();

        TerminalUI.SmoothPrintLine("What do you want the description of your goal to be?");
        string goalDescription = Console.ReadLine();


        
        int userChoice = TerminalUI.RunIntMenu(GoalOptionsMenu, 3);
        
        
        if (userChoice == 1)
        {
            Goals.Add(new EternalGoal{
                Name = goalName, 
                Description = goalDescription
            });
        }
        else if (userChoice == 2)
        {
            int checkAmount = TerminalUI.GetInt(rangeEnd:1000, prompt:"How many times would you like to complete the task?(how many boxes on your checklist?):");
            Goals.Add(new ChecklistGoal{
                Name = goalName,
                Description = goalDescription,
                TimesCompleted = 0,
                TotalChecks = checkAmount
            });
        }
        else if (userChoice == 3)
        {
            Goals.Add(new SimpleGoal{
                Name = goalName,
                Description = goalDescription
            }); ;
        }
        

        TerminalUI.SmoothPrintLine($"""Goal "{goalName}" created""");
    }
    private void UpdateGoal()
    {
        string userInput;

        while (true)
        {
            TerminalUI.SmoothPrintLine("What is the name of the Goal would you like to Update?(Enter 0 to exit): ");
            userInput = Console.ReadLine();

            if (userInput == "0")
            {
                break;
            }

            foreach (Goal goal in Goals)
            {
                if (goal.Name == userInput)
                {
                    AddPoints(goal.UpdateGoal());
                    break;
                }
            }

            TerminalUI.SmoothPrintLine("Incorrect input.\nPress enter to continue");
        }
    }
    private void RemoveGoal()
    {
        string userInput;

        while (true)
        {
            TerminalUI.SmoothPrintLine("What is the name of the Goal would you like to remove?(Enter 0 to exit): ");
            userInput = Console.ReadLine();

            if (userInput == "0")
            {
                break;
            }

            foreach(Goal goal in Goals)
            {
                if (goal.Name == userInput)
                {

                    TerminalUI.SmoothPrintLine($"""Goal "{goal.Name}" deleted.\nPress Enter to continue.""");
                    Goals.Remove(goal);
                    Console.ReadLine();
                    break;
                }
            }

            TerminalUI.SmoothPrintLine("Incorrect input.\nPress enter to continue");
        } 
        
    }
    private void CreateSimpleGoal()
    {

    }
    private void CreateChecklistGoal()
    {

    }
    private void AddPoints(int points)
    {
        TerminalUI.SmoothPrintLine($"You gained {points} points!\nPress Enter to continue.");
        Console.ReadLine();
        Points += points;
    }
    private void CreateEternalGoal()
    {

    }
    private void DiplayGoals()
    {
        foreach (Goal goal in Goals)
        {
            goal.Display();
        }
        TerminalUI.SmoothPrintLine("Press Enter to continue.", clearBeforePrint:false);
    }
}