class User {
    private string userName = "Default Username";
    private bool isGamified = false;
    private List<SimpleGoal> _simpleGoals;
    private List<EternalGoal> _eternalGoals;
    private List<ChecklistGoal> _checklistGoals;
    private int _pointsTotal;

    public User() {
        string userInput;
        Console.Clear();
        Console.WriteLine("Greetings, friend! (Press Enter)");
        userInput = Console.ReadLine();
        Console.WriteLine("Welcome to a great new adventure. The goals you make and reach here will change your life for the better. (Press Enter)");
        userInput = Console.ReadLine();
        Console.WriteLine("Tell me, what should I call you? (Enter your name:)");
        userName = Console.ReadLine();

        do{
            Console.WriteLine($"{userName}? Pleased to meet you! You can call me Calanthe. (Press Enter)");
            userInput = Console.ReadLine();
            Console.WriteLine("I can make this a little more fun or a little more serious for you. Please type Y if you're OK with me gamifying your experience, or N if you're not. (You can change this later.)");
            userInput = Console.ReadLine();
        } while(!(userInput == "Y" || userInput == "N"));

    }

    public void NewGoal() {

    }
    public void UpdateGoal() {

    }

    public void DisplayGoalOfType() {

    }

    public void DisplayPoints() {

    }    
}