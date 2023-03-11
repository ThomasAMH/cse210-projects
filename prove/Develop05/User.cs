using System.Text.Json;
public class User {
    private string userName = "Default Username";
    private bool isGamified = false;
    private List<SimpleGoal> _simpleGoals = new List<SimpleGoal>();
    private List<SimpleGoal> _completedSimpleGoals = new List<SimpleGoal>();
    private List<EternalGoal> _eternalGoals = new List<EternalGoal>();
    private List<ChecklistGoal> _checklistGoals = new List<ChecklistGoal>();
    private List<ChecklistGoal> _completedChecklistGoals = new List<ChecklistGoal>();
    public int pointsTotal = 0;

    public User() {
        string userInput;
        Console.Clear();
        Console.WriteLine("Greetings, friend! (Press Enter)");
        userInput = Console.ReadLine();
        
        Console.WriteLine("Welcome to a great new adventure. The goals you make and reach here will change your life for the better. (Press Enter)");
        userInput = Console.ReadLine();
        
        Console.WriteLine("Tell me, what should I call you? (Enter your name)");
        userName = Console.ReadLine();
        

        Console.WriteLine($"{userName}? Pleased to meet you! (Press Enter)");
        userInput = Console.ReadLine();
       

        Console.WriteLine("I can make this a little more fun or a little more serious for you. Please type Y if you're OK with me gamifying your experience, or N if you're not. (You can change this later.)");
        userInput = Console.ReadLine();
    
 

        if(userInput == "Y") {isGamified = true;} else {
            isGamified = false;
            }

        Console.WriteLine("Noted, thanks! Let's get started! :) (Press Enter)");
        userInput = Console.ReadLine();
        Console.WriteLine("");
    }

    public void NewGoal() {
        Console.Clear();
        Console.WriteLine("Sure thing. What kind?");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");;
        Console.WriteLine("Select a choice from the menu by entering the corrisponding number:");

        
        int userInt = int.Parse(Console.ReadLine());

        switch(userInt) {
            case 1:
                _simpleGoals.Add(new SimpleGoal());
                break;
            case 2:
                _eternalGoals.Add(new EternalGoal());
                break;
            case 3:
                _checklistGoals.Add(new ChecklistGoal());
                break;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
    public void UpdateGoal(string type, int userIndex) {
        switch(type) {
            case "Simple":
                _simpleGoals[userIndex-1].RecordEvent(this);
                _completedSimpleGoals.Add(_simpleGoals[userIndex-1]);
                _simpleGoals.RemoveAt(userIndex-1);
            break;
            
            case "Eternal":
                _eternalGoals[userIndex-1].RecordEvent(this);          
            break;
            
            case "Checklist":
                _checklistGoals[userIndex-1].RecordEvent(this);

                if(_checklistGoals[userIndex-1].isCompleted) {
                    _completedChecklistGoals.Add(_checklistGoals[userIndex-1]);
                    _checklistGoals.RemoveAt(userIndex-1);
                }
            break;
        }
}   

    public void DisplayGoalOfType(string type) {
        Console.Clear();
        int i = 1;
        switch(type) {
            case "Simple":
                if(_simpleGoals.Count == 0) {
                    Console.WriteLine("No simple goals to show");
                    break;
                }
                foreach(SimpleGoal g in _simpleGoals) {
                    g.PrintIsCompleteString();
                    Console.Write(" " + i + ". " + g.goalText);
                    Console.WriteLine("");
                    i++;
                }
                break;
            case "Eternal":
                if(_eternalGoals.Count == 0) {
                    Console.WriteLine("No eternal goals to show");
                    break;
                }            
                foreach(EternalGoal g in _eternalGoals) {
                    g.PrintIsCompleteString();
                    Console.Write(" " + i + " " + g.goalText);
                    Console.WriteLine("");
                    i++;
                }            
                break;
            case "Checklist":
                if(_checklistGoals.Count == 0) {
                    Console.WriteLine("No checklist goals to show");
                    break;
                }            
                foreach(ChecklistGoal g in _checklistGoals) {
                    g.PrintIsCompleteString();
                    Console.Write(" " + i + " " + g.goalText);
                    Console.WriteLine("");
                    i++;
                }                
                break;
            case "Completed":
                break;
        }
        
        Console.WriteLine("Press Enter to continue");
        string unused = Console.ReadLine();
    }

    public void DisplayCompletedGoals() {
        Console.Clear();
        string unused;
        if(_completedSimpleGoals.Count == 0) {
            Console.WriteLine("No simple goals to show");
        } else {
            foreach(SimpleGoal g in _completedSimpleGoals) {
                g.PrintIsCompleteString();
                Console.Write(" " + g.goalText);
                Console.WriteLine("");
            }     
        }    
        Console.WriteLine("Press Enter to continue");
        unused = Console.ReadLine();

        if(_completedChecklistGoals.Count == 0) {
            Console.WriteLine("No eternal goals to show");
        } else {
            foreach(ChecklistGoal g in _completedChecklistGoals) {
                g.PrintIsCompleteString();
                Console.Write(" " + g.goalText);
                Console.WriteLine("");
            }
        }
        Console.WriteLine("Press Enter to continue");
        unused = Console.ReadLine();
    }

    public void DisplayPoints() {
        Console.Clear();
        Console.WriteLine("Total points: " + pointsTotal);
        Console.WriteLine("Press Enter to continue");
        string unused = Console.ReadLine();
    }

    public void ToggleGamification() {
        Console.Clear();
        isGamified = !isGamified;
        Console.WriteLine("Is Gameified: " + isGamified);
    }

    public string PackageObject() {
        string objectString;

        objectString = JsonSerializer.Serialize(_simpleGoals);
        return objectString;
    }
}