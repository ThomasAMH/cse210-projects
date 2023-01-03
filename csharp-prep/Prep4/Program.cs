using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Define variables
        List<int> userIntList = new List<int>();
        string userInput = "";
        do {

            Console.WriteLine("Enter a number (enter 0 to quit)");
            userInput = Console.ReadLine();
            userIntList.Add(int.Parse(userInput));

        } while (int.Parse(userInput) != 0 );

        Console.WriteLine($"The sum of the list is: {userIntList.Sum()}");
        Console.WriteLine($"The average of the list is: {userIntList.Average()}");
        Console.WriteLine($"The largest number is: {userIntList.Max()}");
    } 
}