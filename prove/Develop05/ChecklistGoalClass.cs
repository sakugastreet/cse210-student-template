using System.Text.Json;

class ChecklistGoal : Goal
{
    public int TimesCompleted { get; set; }
    public int TotalChecks { get; set; }


    public ChecklistGoal() : base()
    {

    }
    public ChecklistGoal(string name, string description, int points = 0) : base(name, points, description)
    {

    }

    public override string SerializeGoal()
    {
        // throw new NotImplementedException();


        return JsonSerializer.Serialize(this);

    }

    public override int UpdateGoal()
    {
        if (completed)
        {
            TerminalUI.SmoothPrintLine("this Goal has already been completed.");
            return 0;
        }
        bool Y_N = TerminalUI.GetStringYN("Do you want to check off another square in this box?(Enter Yes/No)");
        if (Y_N)
        {
            TimesCompleted += 1;
            if (TimesCompleted == TotalChecks)
            {
                completed = true;
                TerminalUI.SmoothPrintLine("Goal completed! Bonus 50 points!\nPress Enter to Continue.");
                Console.ReadLine();
                return Points + 50;
            }
            return Points;
        }
        return 0;
    }
}