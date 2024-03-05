using System.Diagnostics;

class ListingActivity : Activity
{
    List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    List<string> userEntries = new List<string>{};

    public ListingActivity(int activityInt) : base(activityInt)
    {
    }

    protected override void RunActivity()
    {
        SetDelayLength(); 
        Random random = new Random();
        TerminalUI.SmoothPrintLine(_prompts[random.Next(0, 4)]);
        TerminalUI.SmoothPrintLine("Press Enter when you are ready to begin.", clearBeforePrint:false);
        Console.ReadLine();

    
        TerminalUI.SmoothPrintLine($"Please take the next {_delayLength} seconds to list as many things as you can that relate to the prompt(press enter inbetween each item)", clearBeforePrint: false);
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed.TotalSeconds < _delayLength)
        {
            userEntries.Add(Console.ReadLine());
        }

        stopwatch.Stop();
        TerminalUI.SmoothPrintLine($"You entered a total of {userEntries.Count} items. Good Job!");
        TerminalUI.SmoothPrintLine("Press Enter to Continue", clearBeforePrint:false);
        Console.ReadLine();

        
    }
}