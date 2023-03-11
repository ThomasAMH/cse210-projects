class ChecklistGoal : Goal {

    private int _totalNeededCompletionChecks = 0;
    private int _currentCompletionChecks = 0;
    private int _bonusPoints = 0;


    public ChecklistGoal() {
        Console.Clear();
        description = "These are goals that must be done several times before they're truely complete.";
        Console.WriteLine(description);
        Console.WriteLine("");
        
        Console.WriteLine("Write your goal here:");
        goalText = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("How many times do you need to do this?");
        _totalNeededCompletionChecks = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        
        Console.WriteLine("How many points is this goal worth per log? (Integers only!):");
        pointValue = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        Console.WriteLine("How many points will you get at the end? (Integers only!):");
        _bonusPoints = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        isCompleted = false;

        Console.WriteLine("Goal recorded. Press Enter to continue");
        string unused = Console.ReadLine();
    }
    public ChecklistGoal(string fileGoalText, bool fileIsCompleted, int filePointsValue, int fileBonusPointValue, int fileCurrentCompletion, int fileTotalNeededCompletion) {
        description = "These are goals that must be done several times before they're truely complete.";
        goalText = fileGoalText;
        isCompleted = fileIsCompleted;
        pointValue = filePointsValue;
        _bonusPoints = fileBonusPointValue;
        _currentCompletionChecks = fileCurrentCompletion;
        _totalNeededCompletionChecks = fileTotalNeededCompletion;
    }

    public override void RecordEvent(User associatedUser) {
        _currentCompletionChecks++;

        if(_currentCompletionChecks == _totalNeededCompletionChecks)
        {
            isCompleted = true;
            associatedUser.pointsTotal += pointValue;
            associatedUser.pointsTotal += _bonusPoints;
        } else {
            associatedUser.pointsTotal += pointValue;
        }
    }
    public override void PrintIsCompleteString() {
        if(isCompleted) {
            Console.Write("[X]");
        } else {
            Console.Write($"{_currentCompletionChecks}/{_totalNeededCompletionChecks}");
        }
    }

        public override string StringifyObject() {
        //Store data in accordinace with the object structure found in objectStructure.txt
        string stringifiedObject = "";
        stringifiedObject += goalText + "\n";
        stringifiedObject += isCompleted.ToString() + "\n";
        stringifiedObject += pointValue.ToString() + "\n";
        stringifiedObject += _bonusPoints.ToString() + "\n";
        stringifiedObject += _currentCompletionChecks.ToString() + "\n";
        stringifiedObject += _totalNeededCompletionChecks.ToString();

        return stringifiedObject;
    }
}