class ListingActivity : Activity {
    private string _PromptsFilePath = "listing_prompts.txt";
    private string[] _Prompts;
    private List<string> _UserResponses = new List<string>();
    private int _PostPromptPauseDuration = 5;

    public ListingActivity() {
        _Prompts = System.IO.File.ReadAllLines(_PromptsFilePath);
        ActivityName = "Listing Activity";
        ActivityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can.";
    }

    public void RunListingActivity() {
        Console.Clear();
        DisplayStartingMessage();
        DisplayPauseAnimation();
        
        Console.Clear();
        Console.WriteLine("List as many responses to the following prompt:");
        WriteRandomPrompt();
        Console.WriteLine("");
        Console.Write("You may begin in...");
        Countdown(_PostPromptPauseDuration);
        Console.WriteLine("");
        
        _FinishTime = DateTime.Now.AddSeconds(ActivityDurationSeconds);
        while(!TimeOut()) {
        Console.Write("> ");
        _UserResponses.Add(Console.ReadLine());
        }
        
        Console.WriteLine($"You listed {_UserResponses.Count} items!");

        DisplayEndingMessage();
    }
    private void WriteRandomPrompt() {
        Random rand = new Random();
        string randomPrompt = _Prompts[rand.Next(_Prompts.Length)];
        Console.WriteLine($"  ---- {randomPrompt} ----  ");
    }
}