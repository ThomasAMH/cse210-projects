using System;

class TestClass {

    public void Entry() {
        Entry testEntry = new Entry("Test Prompt");
        while (true)
        {
            Console.WriteLine("1. Add Entry | 2. Read Entries");
            string developerInput = "";
            developerInput = Console.ReadLine();
            if(int.Parse(developerInput) == 1) {testEntry.WriteEntry();}
            else if(int.Parse(developerInput) == 2) {testEntry.DisplayEntryPages();}
            else {break;}
        }
    }
}