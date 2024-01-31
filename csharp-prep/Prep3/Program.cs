using System;
using System.Net;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;



class Program
{

    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);
        int userGuess;
        int guessAmount = 0;

        do
        {
            guessAmount += 1;
            Console.Write("Please enter a guess: ");
            userGuess = int.Parse(Console.ReadLine());
            if (userGuess == magicNumber)
            {
                Console.WriteLine($"Gongratulations! You got it in {guessAmount}");
            }
            else if (userGuess >= magicNumber)
            {
                Console.WriteLine("Lower!");
            }
            else
            {
                Console.WriteLine("Higher!");
            }


    
        } while (userGuess != magicNumber);



        }  
    }  
    