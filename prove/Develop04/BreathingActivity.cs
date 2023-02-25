class BreathingActivity : Activity {
    //Hard coded activity specific values
    private int BreatheInTimeSeconds = 5;
    private int BreatheoutTimeSeconds = 6;

    public BreathingActivity() {
        ActivityName = "Breathing Activity";
        ActivityDescription = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }
    public void RunBreathingActivity() {
        Console.Clear();
        DisplayStartingMessage();
        DisplayPauseAnimation();
        _FinishTime = DateTime.Now.AddSeconds(ActivityDurationSeconds);
        
        while(!TimeOut()) {
            Console.WriteLine("Breathe in...");
            Countdown(BreatheInTimeSeconds);
            Console.WriteLine("Breathe out...");
            Countdown(BreatheoutTimeSeconds);
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }
}