
class AppControls
{
    public bool _journalOpen = false;
    public void OpenJournal() {
        //Display all journals / .csv files in current directory
        Console.WriteLine("Which journal would you like to open?");
        //Get use input for which journal to open. 0 to cancel.
    }

    public Journal CreateJournal() {
        Journal newJournal = new Journal();
        return newJournal;
    }

    public void SaveJournal(string destination) {
        //Write journal Data first
        
        //Then journal entries
    }

    public void DisplayInitialMenu() {
        Console.WriteLine("Welcome to The Journal Persona!");
    }

    public void CloseApp() {
        Console.WriteLine("Closing Application...");
    }

    public bool IsIntegerWithinRange(string userInput, int lowerLimit, int upperLimit ) {
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