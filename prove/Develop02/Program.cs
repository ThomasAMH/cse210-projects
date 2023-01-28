using System;

class Program
{
    static void Main(string[] args)
    {
        //Initiate application-level controls
        AppControls app = new AppControls();
        bool initialMenuDisplayed = false;
        bool continueExecution = true;
        string userInput = "";
        int userInt;
        Journal ActiveJournal = null;

        //Main Menu
        while(continueExecution) {
            if(!initialMenuDisplayed) { app.DisplayInitialMenu(); initialMenuDisplayed = true;}

            Console.WriteLine("Please enter one of the following menu options:");
            Console.WriteLine("0: Close Application");

            //Display Limited Menu Options
            if(!app._journalOpen) {  
                Console.WriteLine("0. Quit Program");
                Console.WriteLine("1: Open Journal");
                Console.WriteLine("2. New Journal");
                Console.WriteLine("3. TEST Entry Functions");

                //Get and check user input
                userInput = Console.ReadLine();
                //TEST
                if(!(app.IsIntegerWithinRange(userInput, 0, 3))) {continue;}
                userInt = int.Parse(userInput);

                //Execute User Input
                switch(userInt)
                {
                    case 0:
                        app.CloseApp(); continueExecution = false; break;
                    //case 1:
                    case 2:
                        ActiveJournal = app.CreateJournal(); app._journalOpen = true; break;
                    
                }
                ///TEST
                //else if (userInt == 3) {TestClass test = new TestClass(); test.Entry();}
            }
                
            //Display Full Menu Options            
            else {
                Console.WriteLine("");
                Console.WriteLine($"Active Journal: {ActiveJournal._journalName}");
                Console.WriteLine("0. Quit Program");
                Console.WriteLine("1. Add Entry");
                Console.WriteLine("2. Read Entries (Chronologically)");
                Console.WriteLine("3. About Journal");
                Console.WriteLine("");

                //Get and check user input
                userInput = Console.ReadLine();
                if(!(app.IsIntegerWithinRange(userInput, 0, 3))) {continue;}
                userInt = int.Parse(userInput);
                //Execute User Input
                switch(userInt) {
                    case 0:
                        app.CloseApp(); continueExecution = false; break;
                    case 1:
                        ActiveJournal.AddEntry(); break;
                    case 2:
                        ActiveJournal.ReadEntries(); break;
                    case 3:
                        ActiveJournal.DisplayAboutInfo(); break;
                    
                }
            }
        }
    }


}