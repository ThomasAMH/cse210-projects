public class Resume {
    public string _personName;
    public List<Job> _personJobs = new List<Job>();

    public Resume() {}

    public void DisplayDetails() {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine($"Jobs:");

        foreach (Job j in _personJobs) {
            j.DisplayJobDetails();
        }
    }
}