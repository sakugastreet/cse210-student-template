using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment blah = new MathAssignment(
            "jimmie", "music", "7:3", "1000 X 3"
            );

        Console.WriteLine(blah.GetSummary());
        Console.WriteLine();
        Console.WriteLine(blah.GetHomework());

        WritingAssignment oof = new WritingAssignment(
            "jimmie", "music", "Kim and the CIA take out France- Nuclear Style"
            );

        Console.WriteLine(oof.GetSummary());
        Console.WriteLine();
        Console.WriteLine(oof.GetWritingInformation());
    }
}