using System.Diagnostics;

class BreathingActivity : Activity
{

    public BreathingActivity(int activityInt) : base(activityInt)
    {
    }

    protected override void RunActivity()
    {
        SetDelayLength(); 
        TerminalUI.SmoothPrintLine("Clear your mind and focus on your breathing.\nPress Enter to Start");
        Console.ReadLine();

    

        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed.TotalSeconds < _delayLength)
        {

            TerminalUI.SmoothPrint("Breath in", 15);
            TerminalUI.SmoothPrintLine(_animString, 1000, false);

            TerminalUI.SmoothPrint("Breath out", 15);
            foreach (char c in _animString)
            {
                TerminalUI.SmoothPrint(c.ToString(), 1000, false);
                // if (stopwatch.Elapsed.TotalSeconds < _delayLength)
                // {
                //     break;
                // }
            }
        }

        stopwatch.Stop();
        
    }
}