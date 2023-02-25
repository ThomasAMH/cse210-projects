class App {

    private int userInt;

    bool continueExecution = true;

    public void RunApplication() {
        while(continueExecution) {
            DisplayMenu();
        }
    }
    private void DisplayMenu() {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Start breathing activity");
        Console.WriteLine(" 2. Start reflecting activity");
        Console.WriteLine(" 3. Start listing activity");
        Console.WriteLine(" 4. Quit");
        Console.WriteLine("Select a choice from the menu:");
        userInt = int.Parse(Console.ReadLine());

        switch(userInt) {
            case 1:
                BreathingActivity BreathingActivityRoutine = new BreathingActivity();
                BreathingActivityRoutine.RunBreathingActivity();
                break;
            case 2:
                ReflectionActivity ReflectionActivityroutine = new ReflectionActivity();
                ReflectionActivityroutine.RunReflectionActivity();
                break;
            case 3:
                ListingActivity ListingActivityroutine = new ListingActivity();
                ListingActivityroutine.RunListingActivity();
                break;
            case 4:
                continueExecution = false;
                break;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
}