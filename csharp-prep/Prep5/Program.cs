using System;

class Program
{
    static void Main(string[] args)
    {
        string userName = "";
        int userNumber = 0;
        static void DisplayWelcome() {
            Console.WriteLine("Welcome to the Program!");
        };

        static string PromptUserName() {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        };

        static int PromptUserNumber() {
            Console.WriteLine("What is your favorite number?");
            return int.Parse(Console.ReadLine());
        };

        static int SquareNumber(int someNumber) {
            return someNumber * someNumber;
        };

        static void DisplayResult(int squaredNumber, string userName) {
            Console.WriteLine($"Your name is: {userName}");
            Console.WriteLine($"Your number squared is: {squaredNumber}");
        };
        
        //Main
        DisplayWelcome();
        userName = PromptUserName();
        userNumber = PromptUserNumber();
        DisplayResult(SquareNumber(userNumber), userName);

    }
}