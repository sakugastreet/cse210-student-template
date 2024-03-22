using System.Text.Json;

class SimpleGoal : Goal
{



    public SimpleGoal() : base()
    {

    }
    public SimpleGoal(string name, string description, int points = 0) : base(name, points, description)
    {

    }

    public override string SerializeGoal()
    {
        // throw new NotImplementedException();


        return JsonSerializer.Serialize(this);

    }

    public override int UpdateGoal()
    {
        bool Y_N = TerminalUI.GetStringYN("Has this Goal been completed?");
        if (Y_N)
        {
            return Points;
        }
        return 0;
    }
}