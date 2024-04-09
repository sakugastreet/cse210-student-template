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
    [NotNull]
    public string Name { get; set; }
    [NotNull]
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
        if (UserContent == null)
        {
            UserContent = new List<Content> {};
        }
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
                SearchCatalog(_context);
            }

            else if (userChoice == 0)
            {
                break;
            }
        }
    }
    private void SearchCatalog(LibraryContext context)
    {
        int userChoice;
        List<string> searchLine = new List<string> {};

        TerminalUI.SmoothPrintLine("Enter Your Search:");
        string searchString = Console.ReadLine();

        var searchResults = context.Contents.Where(
            i => i.Title.Contains(searchString) &&
            i.Category.Contains(searchString)           
        ).ToList();
        foreach (var item in searchResults)
        {
            searchLine.Add(item.ToString());
        }

        List<string> searchMenu = MakeSearchMenu(searchLine);
        // running a menu for all the search Items
        while (true)
        {
            userChoice = TerminalUI.RunIntMenu(searchMenu, searchLine.Count);
            if (userChoice == 0)
            {
                break;
            }
            else
            {
                searchResults[userChoice - 1].SearchedMain(this);
            }
        }

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
            menu.Add($"{count} - " + item.ToString());
            count ++;
        }

        return menu;
    }
    private List<string> MakeSearchMenu(List<string> searchLines)
    {

        List<string> menu = new List<string> {
            "ITEMS FOUND:"
        };
        int count = 1;
        foreach (string line in searchLines)
        {
            menu.Add($"{count} - {line}.");
            count++;
        }

        return menu;
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
                    UserContent[userChoice - 1].BorrowedMain(this);
                }
            }
        }
    }
    public void AddContentToUser(Content content)
    {
        UserContent.Add(content);
        TerminalUI.StringPressToContinue("Item Checked Out!");
    }
    public void RemoveContentFromUser(Content content)
    {
        UserContent.Remove(content);
        TerminalUI.StringPressToContinue("Item Returned!");
    }
}