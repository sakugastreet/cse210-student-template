using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

class Program
{

    static void Main(string[] args)
    {
       // creates mainMenu 
        List<string> MainMenu = new List<string> {
                "Welcome. Which User would you like to use:",
                "0 - End Program",
                "1 - New User"
            };
        
        List<string> options = new List<string> {};

        // Adds the Users in Order to the Menu lines
        // Also adds the Serialized to the options list
        List<string> Users = TerminalUI.ReadTXTFile("Users.txt");


        // if there are no files for users it creates one
        // and jumps into it's menu
        if (Users.Count() == 0)
        {
            TerminalUI.SmoothPrintLine("There seem to be no users. Please enter your full name:");  
            User user = new User{
                Name = Console.ReadLine(),
                Points = 0,
                Goals = new List<Goal> {}
            };
            user.Main();
            string jsonstring = user.Name + ">>>" + user.SerializeUser();
            Users.Insert(0, jsonstring);            
        }

        // or else it sets up for you to open the others.
        

        int index = 2;
        foreach(string line in Users)
        {
            string[] splitLine = line.Split(">>>");
            MainMenu.Add($"{index} - {splitLine[0]}");
            options.Add(splitLine[1]);
            index++;
        }

        while (true)
        {
            int UserChoice = TerminalUI.RunIntMenu(MainMenu, index);
            if (UserChoice == 0)
            {
                break;
            }
            if (UserChoice == 1)
            {
                TerminalUI.SmoothPrintLine("There seem to be no users. Please enter your full name:");
                User user = new User
                {
                    Name = Console.ReadLine(),
                    Points = 0,
                    Goals = new List<Goal> {}
                };
                user.Main();
                string newjsonstring = user.Name + ">>>" + user.SerializeUser();
                Users.Insert(0, newjsonstring);
                string[] splitLine = newjsonstring.Split(">>>");
                MainMenu.Add($"1 - {splitLine[0]}");
                options.Add(splitLine[1]);
            }
            else
            {
                User newuser = JsonSerializer.Deserialize<User>(options[UserChoice - 2]);
                newuser.Main();
                string jsonstring = newuser.Name + ">>>" + newuser.SerializeUser();
                Users.Insert(0, jsonstring);
            }
        }


        TerminalUI.SmoothPrintLine("Thanks for using this program", clearBeforePrint:false);
        TerminalUI.WriteTXTFile(Users, "Users.txt");
    } 
}
