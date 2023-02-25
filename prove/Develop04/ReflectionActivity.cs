class ReflectionActivity : Activity {
    private string _PromptsFilePath = "reflection_prompts.txt";
    private string[] _Prompts;
    private string _QuestionsFilePath = "reflection_questions.txt";
    private string[] _Questions;
    private string notUsed;
    private int _PostPromptPauseDuration = 7;

    public ReflectionActivity() {
        _Prompts = System.IO.File.ReadAllLines(_PromptsFilePath);
        _Questions = System.IO.File.ReadAllLines(_QuestionsFilePath);
        ActivityName = "Reflection Activity";
        ActivityDescription = "This activity will help you reflect on things in your life and help you be more mindful of the events you experience.";
    }

    public void RunReflectionActivity() {
        Console.Clear();
        DisplayStartingMessage();
        DisplayPauseAnimation();
        
        Console.Clear();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("");
        WriteRandomElement("Prompt");
        Console.WriteLine("");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        notUsed = Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in...");
        Countdown(_PostPromptPauseDuration);
        Console.WriteLine("");
        
        _FinishTime = DateTime.Now.AddSeconds(ActivityDurationSeconds);
        while(!TimeOut()) {
            WriteRandomElement("Question");
            DisplayPauseAnimation();
        }
        
        Console.WriteLine();
        DisplayEndingMessage();
    }

    private void WriteRandomElement(string element) {
        Random rand = new Random();

        if(element == "Prompt")
        {
            string randomPrompt = _Prompts[rand.Next(_Prompts.Length)];
            Console.WriteLine($"  ---- {randomPrompt}... ----  ");
        }
        else if(element == "Question") {
            string randomQuestion = _Questions[rand.Next(_Questions.Length)];
            Console.WriteLine($">{randomQuestion}"); 
        }
    }
}
