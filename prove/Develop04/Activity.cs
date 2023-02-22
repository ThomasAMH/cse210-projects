abstract class Activity {
    //Used with children classes: ListingActivity, ReflectionActivity, BreathingActivity. Not to be used alone.
    //This class provides methods and attributes that are used by the children classes to avoid repetition.
    //This class has no public returnables.

//Hard coded values for use by all child classes for uniform behavior
    private int _PauseDuration = 6;
    private string _EndingMessage = "All done! ~(*.*~) (~*.*)~";
    //Used for animating the waiting animation
    private string[] _WaitingAnimationFrames = {
        "-___",
        "_-__",
        "__-_",
        "___-"
    };
    protected DateTime _FinishTime;


//Other properties
    protected int ActivityDurationSeconds;
    //These two are hard coded into the child classes
    protected string ActivityName;
    protected string ActivityDescription;

    protected void DisplayStartingMessage() {
        Console.Clear();
        Console.WriteLine($"Now starting: {ActivityName}");
        Console.WriteLine("");
        Console.WriteLine($"{ActivityDescription}");
        Console.WriteLine("");
        Console.WriteLine("How long, in seconds, would you like for your session?");
        ActivityDurationSeconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
    }

    //Activity timer begins AFTER the animation ends.
    //FIXME: Include support for shorter than 4 second pauses!
    protected void DisplayPauseAnimation() {
        int frame = 0;
        for(int i = 0; i < _PauseDuration; i++) {
            Console.Write(_WaitingAnimationFrames[frame]);
            Thread.Sleep(1000);
            if(frame == _WaitingAnimationFrames.Length - 1) {frame = 0;} else {frame++;}
            Console.Write("\b\b\b\b");
        }
    }
    protected void DisplayEndingMessage() {
        Console.Write(_EndingMessage);
        Console.WriteLine();
        DisplayPauseAnimation();
        Console.Clear();
    }

    protected bool TimeOut() {
        if(_FinishTime < DateTime.Now) {return true;}
        else {return false;};
    }
}