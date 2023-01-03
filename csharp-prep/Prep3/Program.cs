using System;

class Program
{
    static void Main(string[] args)
    {
        //Define classes, variables
        Random randomGenerator = new Random();
        string userInput = "";
        int magicNumber = randomGenerator.Next(1, 11);
        
        Console.WriteLine("This is the magic number game! Try to guess the Magic Number between 1 and 10.");
        //Game loop

        do {
            //Use previously generated magic number
            Console.WriteLine("What is your guess?");
            userInput= Console.ReadLine();

            do {
                if (int.Parse(userInput) == magicNumber) {Console.WriteLine("You guessed it!"); break;}
                else if (int.Parse(userInput) > magicNumber) {
                    Console.WriteLine("Lower");
                    Console.WriteLine("What is your next guess?");
                    userInput= Console.ReadLine();
                    }
                else if (int.Parse(userInput) < magicNumber) {
                    Console.WriteLine("Higher");
                    Console.WriteLine("What is your next guess?");
                    userInput= Console.ReadLine();
                    }
            } while(true);
            
            //Prepare next gamestate. Prompt user to go or quit.
            magicNumber = randomGenerator.Next(1, 11);
            Console.WriteLine("Play again? (Enter yes to repeat, or anything else to quit.)");
            userInput= Console.ReadLine();
            
        } while(userInput == "yes");
        
    }
}