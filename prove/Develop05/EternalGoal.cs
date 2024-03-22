using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

class EternalGoal : Goal
{
    public List <string> History { get; set; }
    public int TimesCompleted {get; set;}

    public EternalGoal() : base()
    {
        
    }
    // public EternalGoal(string name, string description, int points=0) : base(name, points, description)
    // {
    //     TimesCompleted = 0;
    // }

    public void AddDate(string date)
    {
        History.Add(date);
    }

    public override string SerializeGoal()
    {
        // throw new NotImplementedException();


        return JsonSerializer.Serialize(this);
        
    }

    public override int UpdateGoal()
    {
        bool Y_N = TerminalUI.GetStringYN("Did you complete the task for this Goal?(Enter Yes/No)");
        if (Y_N)
        {
            TimesCompleted += 1;
            if (TimesCompleted % 10 == 0)
            {
                TerminalUI.SmoothPrintLine("Goal completed! Bonus 50 points!\nPress Enter to Continue.");
                Console.ReadLine();
                return Points + 50;
            }
            return Points;
        }
        return 0;
    }
}
