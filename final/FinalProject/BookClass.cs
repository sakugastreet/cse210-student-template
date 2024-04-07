using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
public class Book : BorrowableContent
{
    public List<string> Chapters { get; set; }
    public string Author { get; set; }
    [NotMapped]
    private List<string> MainMenu = new List<string> {
        "The Developer has failes to make a Menu here... what a goon bro",
        "you should Probably just enter 0"
    };

    public Book() : base()
    {

    }

    public override void Read()
    {
        TerminalUI.SmoothPrintLine($"{Title}\n by {Author}");
        TerminalUI.ListStringPressToContinue(Chapters);
    }
    public override void Main()
    {
        TerminalUI.RunIntMenu(MainMenu, 1);
    }

}