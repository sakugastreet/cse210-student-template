

public static class MessageLibrary 
{
    static string welcomeMessage = "Welcome.";

    static List<string> activityDescription = new List<string>{
    "This is a default description",
    "This activity will help you relax by walking your through breathing in and out slowly.",
    "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    };

    static string closingMessage = "Thank you for participating";

    static string animString = "....";

    static List<string> delayPrompt = new List<string>{
        "Default Get input delay Prompt",
        "How many seconds would you like to do relaxing breaths for? Please Enter a number between 10 and 180",
        "Please enter the amount of time you would like to reflect.",
        "Please enter the amount of time you would like to list items."

    };


    public static string GetDelayPrompt(int activityInt)
    {
        return delayPrompt[activityInt];
    }
    public static string GetAnimString(int activityInt)
    {
        return animString;
    }

    public static string GetOpeningMessage(int activityInt)
    {
        return welcomeMessage;
    }
    public static string GetActivityDescription(int activityInt)
    {
        return activityDescription[activityInt];
    }
    public static string GetClosingMessage()
    {
        return closingMessage;
    }
}