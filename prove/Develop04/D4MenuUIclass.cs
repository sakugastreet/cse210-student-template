class D4MenuUI
{
    List<string> _menu = new List<string>{
        "Which Activity would you like to do today?",
        "1 - Breathing Activity",
        "2 - Reflection Activity",
        "3 - Listing Activity",
        "",
        "0 - Quit Program"
    };

    private void DisplayMenu()
    {
        foreach (string line in _menu)
        {
            TerminalUI.SmoothPrintLine(line, 7, false);
        }
    }

    public void Main()
    {
        TerminalUI.SmoothPrintLine("Welcome!");
        int userChoice;
        do
        {
            Console.Clear();
            DisplayMenu();
            userChoice = TerminalUI.GetInt(0, 3, "Please enter the number on the menu of the Activity you would like to do.", false);
            if (userChoice == 1)
            {
                BreathingActivity activity1 = new BreathingActivity(userChoice);
                activity1.Main();
            }
            else if (userChoice == 2)
            {
                ReflectionActivity activity2 = new ReflectionActivity(userChoice);
                activity2.Main();
            }
            else if (userChoice == 3)
            {
                ListingActivity activity3 = new ListingActivity(userChoice);
                activity3.Main();
            }

            
        } while (userChoice != 0);

        TerminalUI.SmoothPrint("Thank you for participating today.");
    }
}