class SimpleGoal : Goal {
    public SimpleGoal() {
        Console.Clear();
        description = "These are one and done goals. Once you've checked them off, the points are yours.";
        Console.WriteLine(description);
        Console.WriteLine("");
        
        Console.WriteLine("Write your goal here:");
        goalText = Console.ReadLine();
        Console.WriteLine("");
        
        Console.WriteLine("How many points is this goal worth? (Integers only!):");
        pointValue = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        isCompleted = false;

        Console.WriteLine("Goal recorded. Press Enter to continue");
        string unused = Console.ReadLine();
    }

    public SimpleGoal(string fileGoalText, bool fileIsCompleted, int filePointsValue) {
        description = "These are one and done goals. Once you've checked them off, the points are yours.";
        goalText = fileGoalText;
        isCompleted = fileIsCompleted;
        pointValue = filePointsValue;
    }
}