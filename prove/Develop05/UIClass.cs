using System.ComponentModel.Design;

static class UI
{
     static public int RunIntMenu(List<string> menu, int max, int min=0)
    {
        int UserChoice;
        do
        {

        
            DisplayMenu(menu);
            UserChoice = TerminalUI.GetInt(min, max, "Please Enter Your Choice");
        } while (UserChoice >= min | UserChoice <= max);


        return UserChoice;
    }

    static private void DisplayMenu(List<string> menu)
    {
        Console.Clear();
        foreach (string line in menu)
        {
            TerminalUI.SmoothPrintLine(line, 8, false);
        }

    }    
}