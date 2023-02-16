public class ReviewScripture {
    //List of visible word positions
    private List<int> _positionsList = new List<int>();
    //The mutated verse in an iterateable form
    private string[] _ScriptureWordList;
    private string _userString;
    private bool _lastMutation = false;
    public ReviewScripture(Scripture ActiveScripture) {
        //Composite verse that will be broken up into the array
        string mutatedVerseString = "";

        foreach (Verse v in ActiveScripture.fullScripture) {
            mutatedVerseString = mutatedVerseString + v.VerseText + System.Environment.NewLine;
        }

        //Create an array of words for each verse in the scripture (2D array)
        _ScriptureWordList = mutatedVerseString.Split(" ");
        //Create an array of true's for each word in the scripture
        for (int i = 0; i <= _ScriptureWordList.Count() - 1; i++) {
            _positionsList.Add(i);
        }

        Console.Clear();
        Console.WriteLine($"Now reviewing: {ActiveScripture.FullReference}");
        displayMutatedScripture(_ScriptureWordList);
        _userString = Console.ReadLine();
        
        while(_userString != "Quit") {
            //Display modified scripture
            Console.Clear();
            muatateScripture(_positionsList, _ScriptureWordList);
            displayMutatedScripture(_ScriptureWordList);
            if(_lastMutation) {
                Console.Clear();
                Console.WriteLine("All done!");    
                break;
            }
            Console.WriteLine("Enter Quit to exit, or spam enter.");
            _userString = Console.ReadLine();
        }
    }

    private void muatateScripture(List<int> positionsList, string[] ScriptureWordList) {
        
        //This represents the % of the verse that should be removed.
        const int PERCENT_TO_REMOVE = 10;
        int wordsToRemove = ScriptureWordList.Count() / PERCENT_TO_REMOVE;
        Random rand = new Random();
        int randomInteger;
        int randomPosition;
        string fillerString;
        //rand.Next(incLower, top exlcusive)

        if (positionsList.Count() > wordsToRemove) {
        //In order to remove random words, select a random position from the positions list,
        //Then find that word in the array, replace it with ____'s, then remove the used position from the list.
        //By the final time this function is called, # positions will be less than 10, and all remaining words will be removed.
            for(int i = 1; i <= wordsToRemove; i++) {
                
                //Get a random integer, find a random position in the list, and change the string at that position to ____
                randomInteger = rand.Next(0, positionsList.Count());
                randomPosition = positionsList[randomInteger];

                fillerString = "";
                for(int c = 0; c <= ScriptureWordList[randomPosition].Length - 1; c++) {
                    fillerString = fillerString + "_";
                }

                ScriptureWordList[randomPosition] = ScriptureWordList[randomPosition].Replace(ScriptureWordList[randomPosition], fillerString);
                //Then remove that position from the list.
                positionsList.RemoveAt(randomInteger);
            };
        }

        //If the amount of words is less than scripture length % 10, this is the last leg, remove one each time, then finish
        else {
            for(int i = 1; i <= positionsList.Count(); i++) {
                //As this is the last iteration, change all the remaining words to ___

                fillerString = "";
                for(int c = 0; c <= ScriptureWordList[positionsList[i-1]].Count(); c++) {
                    fillerString = fillerString + "_";
                }
                ScriptureWordList[positionsList[i-1]] = ScriptureWordList[positionsList[i-1]].Replace(ScriptureWordList[positionsList[i-1]], fillerString);
                _lastMutation = true;
            }
        }   
    }

    private void displayMutatedScripture(string[] ScriptureWordList) {
        foreach(string word in ScriptureWordList) {
            Console.Write(word);
            Console.Write(" ");
        }
    }
}