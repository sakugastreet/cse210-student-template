using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public string Description { get; set; }
    public bool completed { get; set; }

    public Goal(string name, int points, string description="Basic Description")
    {
        Name = name;
        Points = points;
        Description = description;
    }

    public Goal()
    {

    }

    public abstract string SerializeGoal();

    public abstract int UpdateGoal();

    public void Display()
    {
        TerminalUI.SmoothPrintLine(Name, clearBeforePrint:false);
        TerminalUI.SmoothPrintLine(Description, clearBeforePrint:false);

    }

}