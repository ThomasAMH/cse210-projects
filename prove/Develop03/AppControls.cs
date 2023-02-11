class ScriptureApp
{
    private bool _ScriptureLoaded = false;
    bool initialMenuDisplayed = false;
    string userInput = "";
    int userInt;
    Scripture ActiveScripture = null;

    public ScriptureApp() {
        DisplayMenu();
    }

    private void DisplayWelcomeMessage() {
        Console.WriteLine("Welcome to The Scripture Memorizer Helper (SMH)!");
    }

    public void DisplayMenu() {
        if (!initialMenuDisplayed) {DisplayWelcomeMessage(); initialMenuDisplayed = true;}

        if (ActiveScripture == null) {PresentNoScriptureMenu();}
        else {PresentScriptureMenu();}
    }

    private void PresentNoScriptureMenu() {
            Console.WriteLine(" ");
            Console.WriteLine("Please enter one of the following menu options:");
            Console.WriteLine("0: Close Application");

            if(!_ScriptureLoaded) {
                Console.WriteLine("1: Enter a Scripture");
                //Console.WriteLine("2. TEST Functions");
                Console.WriteLine("");

                //Get and check user input
                userInput = Console.ReadLine();

                if(!(IsIntegerWithinRange(userInput, 0, 2))) {DisplayMenu();}
                userInt = int.Parse(userInput);

                //Execute User Input
                switch(userInt)
                {
                    case 0:
                        CloseApp(); break;
                    case 1:
                        EnterScriptureMenu(); break;                        
                    // case 2:
                    //     TestClass TestCase = new TestClass(); DisplayMenu(); break;   
                }
            }
    }
    private void PresentScriptureMenu() {
        Console.WriteLine("");
        //Console.WriteLine($"Active Scripture: {ActiveJournal._journalName}");
        Console.WriteLine(" ");
        Console.WriteLine("0. Quit Program");
        Console.WriteLine("1. Memorize Scripture");
        Console.WriteLine("2. Show Scripture");
        Console.WriteLine("3. Remove Scripture");
        // Console.WriteLine("4. TEST functions");
        Console.WriteLine("");

        //Get and check user input
        userInput = Console.ReadLine();
        if(!(IsIntegerWithinRange(userInput, 0, 4))) {DisplayMenu();}
        userInt = int.Parse(userInput);

        //Execute User Input
        switch(userInt) {
            case 0:
                CloseApp(); break;
            case 1:
                ReviewScripture subApp = new ReviewScripture(ActiveScripture); DisplayMenu(); break;
            case 2:
                foreach (Verse v in ActiveScripture.fullScripture) {
                    Console.WriteLine(v.FullReference);
                    Console.WriteLine(v.VerseText);
                    Console.WriteLine("");
                }
                Console.WriteLine("Press Enter to continue");
                userInput = Console.ReadLine();
                Console.Clear();
                DisplayMenu();
                break;
            case 3:
                ActiveScripture = null;
                _ScriptureLoaded = false;
                DisplayMenu();
                break;
            // case 4:
            //     TestClass TestCase = new TestClass(); DisplayMenu(); break;
        }
    }
    
    private void EnterScriptureMenu() {
        
            Console.WriteLine(" ");
            Console.WriteLine("Please enter one of the following menu options:");
            Console.WriteLine("0: Close Application");

            if(!_ScriptureLoaded) {
                Console.WriteLine("1: Single Verse");
                Console.WriteLine("2. Multiple Verse");

                //Get and check user input
                userInput = Console.ReadLine();

                if(!(IsIntegerWithinRange(userInput, 0, 2))) {EnterScriptureMenu();}
                userInt = int.Parse(userInput);
                    int verseNumber, chapterNumber, startVerseNumber, endVerseNumber;
                    string bookName;
                //Execute User Input
                switch(userInt)
                {
                    case 0:
                        CloseApp(); break;
                    case 1:
                    //Single Verse
                    //FIXME: Does not filter user input! User input must be integer.
                        Console.WriteLine("");
                        Console.WriteLine("Enter book name:");
                        bookName = Console.ReadLine();

                        Console.WriteLine("Enter chapter number:");
                        chapterNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter verse number:");
                        verseNumber = int.Parse(Console.ReadLine());

                        ActiveScripture = new Scripture(bookName, chapterNumber, verseNumber);
                        DisplayMenu();
                        break;
                    case 2:
                    //Multiple Verse
                    //FIXME: Does not filter user input! User input must be integer, and end verse should not be smaller than start verse.
                        Console.WriteLine("Enter book name:");
                        bookName = Console.ReadLine();

                        Console.WriteLine("Enter chapter number:");
                        chapterNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter starting verse number:");
                        startVerseNumber = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter final verse number:");
                        endVerseNumber = int.Parse(Console.ReadLine());

                        ActiveScripture = new Scripture(bookName, chapterNumber, startVerseNumber, endVerseNumber);
                        DisplayMenu();
                        break;
                }
            }
    }

    public void CloseApp() {
        Console.WriteLine("Closing Application.");
    }

    private static bool IsIntegerWithinRange(string userInput, int lowerLimit, int upperLimit ) {
        int userInt;
        try {
            userInt = int.Parse(userInput);
        }
        catch(Exception) {
            Console.WriteLine($"Error: That's not a menu option. Accepted input: a number between {lowerLimit} and {upperLimit}");
            return false;
        }
        userInt = int.Parse(userInput);
        if((userInt < lowerLimit) || (userInt > upperLimit)) {
            Console.WriteLine($"Error: That's not a menu option. Accepted input: a number between {lowerLimit} and {upperLimit}");
            return false;
        }
        return true;
    }
    
}