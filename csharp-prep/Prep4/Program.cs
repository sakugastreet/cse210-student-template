using System;
using System.Diagnostics.Metrics;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int newNumber;
        Console.WriteLine("Please enter a number(enter 0 if your done with life and don't want to live anymore)");
        
        do
        {
            Console.Write("Enter Number: ");
            newNumber = int.Parse(Console.ReadLine());
            if (newNumber != 0)
            {
                numbers.Add(newNumber);
            }


        } while (newNumber != 0);

        int listSum = 0;
        int list_largest = 0;
        foreach (int number in numbers)
        {
            listSum += number;
            if (number > list_largest)
            {
                list_largest = number;
            }
        }
        Console.WriteLine($"the Sum of all the numbers you entered is {listSum}");
        Console.WriteLine($"the average of all the numbers you entered is {listSum / numbers.Count}");
        Console.WriteLine($"the largest of all the numbers you entered is {list_largest}");


    }
}