using System;

class Entry {

private List<string> fullEntry = new List<string>();
private string _prompt = "";
private DateTime _creationDate = new DateTime();
public string entryText = "";

public Entry(string prompt = "") {
    _creationDate = DateTime.UtcNow;
    if (prompt != "") {
        _prompt = prompt;
    }
}

public void DisplayEntryPages() {
    string userString = "";
    Console.WriteLine("");
    Console.WriteLine($"Entry Created: {_creationDate}");
    if( _prompt != "") {Console.WriteLine($"Prompt: {_prompt}");}
        
    int i = 1;
    foreach (String s in fullEntry) {

        Console.WriteLine($"Page {i} of {fullEntry.Count} on this entry");
        
        Console.WriteLine("");
        Console.WriteLine(s);
        Console.WriteLine("");
        
        //In the event of only one entry, the user must press enter to move on
        if(fullEntry.Count == 1) {
            Console.WriteLine("This is the only page here. Press Enter to move on.");
            Console.ReadLine();
            break;
        }

        //In the event of the final entry, the user must press enter to move on
        if(fullEntry.Count == i) {
            Console.WriteLine("This is the last page. Press Enter to move on.");
            Console.ReadLine();
            break;
        }
        
        Console.WriteLine("Display next page in entry? Y or N");

        userString = Console.ReadLine();
        while((userString != "Y") && (userString != "N")) {
            Console.WriteLine("Display next page? Y or N");
            userString = Console.ReadLine();
        }

        if(userString == "N") {return;}
        Console.WriteLine("");
        i++;
    }
}

public void WriteEntry() {
    string userString = "";
    if(_prompt != "") {Console.WriteLine($"Prompt: {_prompt}");}
    
    Console.WriteLine("Your Entry Here. (Enter -Q to finish)");
    do {
        userString = Console.ReadLine();
        if(userString == "-Q") {break;}
        fullEntry.Add(userString);
        Console.WriteLine("");
        Console.WriteLine("Keep Writing? (Enter -Q to finish)");
        Console.WriteLine("");
    } while(true);
}

// public List<string> SaveEntriesToFile(string fileName) {
//     //Pack all entries into an array of a string to be saved
//     //# of pages an an entry, then the entry itself
//     //Example:
//     //Entry Creation Date
//     //Prompt
//     //Blablablaf
//     //Bla bla bla

//     }
}