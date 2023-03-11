class EternalGoal : Goal {
        public EternalGoal() {
        Console.Clear();
        description = "These are goals that go on forever, but you get points every time you log an entry.";
        Console.WriteLine(description);
        Console.WriteLine("");
        
        Console.WriteLine("Write your goal here:");
        goalText = Console.ReadLine();
        Console.WriteLine("");
        
        Console.WriteLine("How many points is this goal worth per log? (Integers only!):");
        pointValue = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        isCompleted = false;

        Console.WriteLine("Goal recorded. Press Enter to continue");
        string unused = Console.ReadLine();
    }

    public EternalGoal(string fileGoalText, bool fileIsCompleted, int filePointsValue) {
        description = "These are goals that go on forever, but you get points every time you log an entry.";
        goalText = fileGoalText;
        isCompleted = fileIsCompleted;
        pointValue = filePointsValue;
    }
    public override void RecordEvent(User associatedUser) {
        associatedUser.pointsTotal += pointValue;
    }
    
    public override void PrintIsCompleteString() {
            Console.Write("[-]");
    }
}