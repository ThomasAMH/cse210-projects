using System;

class Journal {   
    private DateTime _creationDate;
    public string _journalName;
    protected string _authorName;
    protected string _authorNote;
    protected bool _enabledPrompts;
    private string promptsPath = "prompts.txt";
    protected List<Entry> _entries  = new List<Entry>();
    private List<string> _promptList = new List<string>();

    public Journal() {
        _creationDate = DateTime.Today;
        Console.WriteLine("Enter Journal Name:");
        _journalName = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Enter Author Name:");
        _authorName = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Enter any notes about the journal, such as descriptions or subtitles  (if any):");
        _authorNote = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Enable Prompts? (Y or N)");
        string userInput = Console.ReadLine();
        while((userInput != "Y") && (userInput != "N")) {
            Console.WriteLine("Enable Prompts? (Y or N)");
            userInput = Console.ReadLine();
        }

        if(userInput == "Y") {GeneratePromptsList(); _enabledPrompts = true;}
    }

    public void AddEntry() {
        Entry entry = null;
        if(_enabledPrompts) {entry = new Entry(PullAPrompt());}
        else {entry = new Entry();}
        entry.WriteEntry();
        _entries.Add(entry);
    }

    public void ReadEntries() {
        string userInput;
        int i = 1;
        foreach (Entry e in _entries) {
            Console.WriteLine($"Now displaying: entry {i} of {_entries.Count}");
            e.DisplayEntryPages();

            if(i < _entries.Count) {
                Console.WriteLine("Display next entry? Y or N?");
                userInput = Console.ReadLine();

                while((userInput != "Y") && (userInput != "N")) {
                    Console.WriteLine("Display next entry? (Y or N)");
                    userInput = Console.ReadLine();
                }
                if(userInput == "N") {break;}
            }
            i++;
        }
    }

    private void GeneratePromptsList() {
        string[] lines = System.IO.File.ReadAllLines(promptsPath);

        foreach (string line in lines) {
            _promptList.Add(line);
        }
    }

    private string PullAPrompt() {
        string randomPrompt;
        var rand = new Random();
        randomPrompt = _promptList[rand.Next(1, _promptList.Count)];
        return randomPrompt;
    }

    public void DisplayAboutInfo() {
    Console.WriteLine("");
    Console.WriteLine($"Journal Name: {_journalName}");
    Console.WriteLine($"Creation Date: {_creationDate}");
    Console.WriteLine($"Author Name: {_authorName}");
    Console.WriteLine($"Author Note: {_authorNote}");
    Console.WriteLine("");
    }

    public List<string> PackageJournalInfo() {
        List<string> journalPackage = new List<string>();
        
        journalPackage.Add(_creationDate.ToShortDateString());
        journalPackage.Add(_journalName);
        journalPackage.Add(_authorName);
        journalPackage.Add(_authorNote);
        journalPackage.Add(_enabledPrompts.ToString());
        journalPackage.Add(promptsPath);

        foreach( Entry e in _entries ) {
            
        }

    
    }
}