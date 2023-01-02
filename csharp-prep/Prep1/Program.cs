using System;

class Program
{
    static void Main(string[] args)
    {        
        //Begin Assignment
        string firstName = "";
        string lastName = "";

        //Get names
        Console.WriteLine("What is your first name?");
        firstName = Console.ReadLine();

        Console.WriteLine("What is your last name?");
        lastName = Console.ReadLine();

        //Print names "James Bond" style
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
             

    }
}