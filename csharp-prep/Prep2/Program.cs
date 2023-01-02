using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        int userPercent = 0;
        string letter = "";
        bool x = true;
            Console.WriteLine("This program accepts INTEGER % scores on assignments and returns the letter grade. A 70 is required to pass. Enter QUIT to exit.");
        
        while (x == true)
        {
            Console.WriteLine("Enter a percentage (enter QUIT) to quit:");
            userInput = Console.ReadLine();

            if (userInput == "QUIT") {break;}
            userPercent = int.Parse(userInput);

            //Assign letter grade
            if (userPercent >= 90) {letter = "A";}
            else if (userPercent >= 80) {letter = "B";}
            else if (userPercent >= 70) {letter = "C";}
            else if (userPercent >= 60) {letter = "D";}
            else {Console.WriteLine("Letter Grade: F");}
            

            //Print
            Console.WriteLine($"Letter Grade: {letter}");
            if (userPercent >= 70) {Console.WriteLine("Class passed. Excellent work");}
            else {Console.WriteLine("Class failed. Learn from your mistakes, and you'll get it next time!");}
        }
    }
}