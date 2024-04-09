using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

public abstract class BorrowableContent : Content
{
    bool IsBorrowed { get; set; }
    bool IsRequested { get; set; }
    [NotMapped]
    List<string> SearchMenu = new List<string> {
        "1 - Open",
        "2 - Check Out",
        "",
        "0 - Back to Search Results"
    };
    [NotMapped]
    List<string> BorrowedMenu = new List<string> {
        "1 - Open",
        "2 - Renew",
        "3 - Return",
        "",
        "0 - Back to User Content"
    };

    public BorrowableContent() : base()
    {

    }


    public override void SearchedMain(User user)
    {
        int userChoice;
        while (true)
        {
            userChoice = TerminalUI.RunIntMenu(SearchMenu, 2);
            {
                if (userChoice == 0)
                {
                    break;
                }
                else if (userChoice == 1)
                {
                    Open();
                }
                else if (userChoice == 2)
                {
                    CheckOut(user);
                }
            }
        }
    }
    public override void BorrowedMain(User user)
    {
        int userChoice;
        while (true)
        {
            userChoice = TerminalUI.RunIntMenu(BorrowedMenu, 3);
            {
                if (userChoice == 0)
                {
                    break;
                }
                else if (userChoice == 1)
                {
                    Open();
                }
                else if (userChoice == 2)
                {
                    Renew();
                }
                else if (userChoice == 3)
                {
                    Return(user);
                }
                
            }
        }
    }
    

    private void CheckOut(User user)
    {
        if (IsBorrowed)
        {
            if (IsRequested)
            {
                TerminalUI.StringPressToContinue("This item has already been checkout and requested by other users. Please check again later.");
            }
            else if (TerminalUI.GetStringYN("This item has already been checked out, would you like to request it?(y/n)"))
            {
                
                IsRequested = true;
                TerminalUI.StringPressToContinue("Item requested");
            }

        }
        else
        {
            if (IsLost)
            {
                TerminalUI.StringPressToContinue("This Item has been lost. Please try again later.");
            }
            else
            {
                IsBorrowed = true;
                user.AddContentToUser(this);
            }
        }
    }
    private void Renew()
    {
        if (IsRequested)
        {
            TerminalUI.StringPressToContinue("This item has been requested by another user. It cannot be renewed.");
        }
        else
        {
            TerminalUI.StringPressToContinue("Item renewed."); ;
        }
    }
    private void Return(User user)
    {
        user.RemoveContentFromUser(this);
    }
}