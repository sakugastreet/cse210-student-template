using System.Data.SqlTypes;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

class LibraryUI
{
    private List<string> TopMenu = new List<string> {
        "Please Enter a Number",
        "",
        "1 - Login",
        "2 - Sign Up",
        "",
        "0 - End Program"
    };

    // LibraryContext context = using (var context = new LibraryContext());
    public LibraryUI()
    {

    }

    public void Main()
    {

        Console.WriteLine("Hello FinalProject World!");
        using (var context = new LibraryContext())
        {
            context.Database.EnsureCreated();

            



            int userChoice;
            while (true)
            {
                userChoice = TerminalUI.RunIntMenu(TopMenu, 2, 0);
            
                if (userChoice == 0)
                {
                    break;
                }
                else if (userChoice == 1)
                {
                    int usersCount = context.Users.Count();
                    if (usersCount <= 0)
                    {
                        TerminalUI.StringPressToContinue("There are no Users. Please sign up");
                    }
                    else
                    {
                        int userID;
                        userID = TerminalUI.GetInt(1, usersCount, "please Enter you LibraryID");
                        User user = context.Users.Find(userID);
                        user.Main();
                    }
                }
                else if (userChoice == 2)
                {
                    TerminalUI.SmoothPrintLine("Welcome New User. What is your name?");
                    string userName = Console.ReadLine();
                    
                    User user = new User(context){
                        Name = userName,
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    TerminalUI.StringPressToContinue($"Thanks for signing up! your Library ID number is {context.Users.Count()}. Please Login to Continue");
                }


                context.SaveChanges();

            }
        }    
        
    }
    private void Login()
    {
    //     int userID = TerminalUI.GetInt(0, context.Users.Count(), "please enter your Library ID");
    //     User user = context.Users.Find(userID);
    //     user.Main();
        TerminalUI.SmoothPrintLine("Login");
    } 
}