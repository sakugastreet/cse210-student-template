using System;
using System.Data.SqlTypes;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main()
    {
        DisplayWelcomeMessage();
        string username = PromptUserName();
        int numberUserLike = PromptUserNumber();
        int squarednumber = SquareNumber(numberUserLike);
        DiplayResult(username, squarednumber);
    }
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Hello Prep5 World!");

    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your full name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("My Good Sir, what is your favorite number? ");
        int favorite_number = int.Parse(Console.ReadLine());

        return favorite_number;
    }

    static int SquareNumber(int number)
    {
        number = number * number;

        return number;
    }

    static void DiplayResult(string username, int number)
    {
        Console.WriteLine($"The user's name is {username} and their number squared is {number}.");
    }
}