using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Xml.Serialization;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

public class User
{

    [Key]
    public int LibraryID { get; set; }
    public string Name { get; set; }
    public List<Content> UserContent { get; set; }
    [NotMapped]
    private List<string> _userMainMenu = new List<string> {
        "1 - View Your Content",
        "2 - Search Library Catalog",
        "",
        "0 - Sign Out"
        };

    [NotMapped]
    private LibraryContext _context;



    public User(LibraryContext context)
    {
        _context = context;
    }

    public void Main()
    {
        int userChoice;
        while (true)
        {
            userChoice = TerminalUI.RunIntMenu(_userMainMenu, 2);
            if (userChoice == 1)
            {
                OpenUserContent();
            }
            else if (userChoice == 2)
            {
                RunSearch();
            }
        }
    }
    private void SearchCatalog()
    {
        string searchstring;
        TerminalUI.SmoothPrintLine("Please enter your search below:");
        searchstring = Console.ReadLine();

    }
    private List<string> MakeContentMenu()
    {

        List<string> menu = new List<string> {
            $"You have {UserContent.Count} items checked out.",
            "Enter the number listed by each item to examine,",
            "return or open it."
        };
        int count = 1;
        foreach (Content item in UserContent)
        {
            menu.Add($"{count}" + item.ToString());
            count ++;
        }

        return menu;
    }
    private void RunSearch()
    {

    }
    private void OpenUserContent()
    {
        if (UserContent.Count == 0)
        {
            TerminalUI.StringPressToContinue("No content found, Press Enter to continue.");
        }
        else
        {
            int userChoice;
            while (true)
            {
                userChoice = TerminalUI.RunIntMenu(MakeContentMenu(), UserContent.Count);
                if (userChoice == 0)
                {
                    break;
                }
                else
                {
                    UserContent[userChoice].Main();
                }
            }
        }
    }
}