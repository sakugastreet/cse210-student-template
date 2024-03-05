using System.Diagnostics;

class ReflectionActivity : Activity
{
    List<string> _timesWhen = new List<string>{
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    List<string> _prompts = new List<string>{
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int activityInt) : base(activityInt)
    {
    }

    protected override void RunActivity()
    {
        SetDelayLength(); 
        Random random = new Random();
        TerminalUI.SmoothPrintLine(_timesWhen[random.Next(0, 3)]);
        TerminalUI.SmoothPrintLine("Press Enter when Ready.", clearBeforePrint: false);
        Console.ReadLine();

    

        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed.TotalSeconds < _delayLength)
        {

            TerminalUI.SmoothPrintLine(_prompts[random.Next(0, 8)], 15);
            TerminalUI.SmoothPrintLine(_animString, 2000, false);
        }

        stopwatch.Stop();
        
    }
}