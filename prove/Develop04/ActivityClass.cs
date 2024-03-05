using System.Diagnostics;

class Activity
{
    protected string _animString = "....";
    protected int _delayLength = 10;
    protected int _activityInt = 0;
    protected string _delayPrompt;


    public Activity (int activityInt)
    {
        _activityInt = activityInt;
        _delayPrompt = MessageLibrary.GetDelayPrompt(activityInt);
        _animString = MessageLibrary.GetAnimString(_activityInt);
    }

    public void Main()
    {
        PrintOpeningMessages();
        RunActivity();
        PrintClosingMessage();
    }


    protected void SetDelayLength()
    {
        _delayLength = TerminalUI.GetInt(1, 50, _delayPrompt);
    }
    private void PrintOpeningMessages()
    {
        TerminalUI.SmoothPrintLine(MessageLibrary.GetOpeningMessage(_activityInt));
        TerminalUI.SmoothPrintLine(MessageLibrary.GetActivityDescription(_activityInt), clearBeforePrint:false);
        Console.Write("Press Enter to Continue");
        Console.ReadLine();
    }    
    private void PrintClosingMessage()
    {
        TerminalUI.SmoothPrint(MessageLibrary.GetClosingMessage());
        TerminalUI.SmoothPrint(":)   ", 250, false);
    }
    protected virtual void RunActivity()
    {
        TerminalUI.SmoothPrintLine("we are running the activity");
    }
    private void RunAnimation()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed.TotalSeconds < _delayLength)
        {
            TerminalUI.SmoothPrintLine(_animString, 500);
        }

        stopwatch.Stop();
        
        
    }
}