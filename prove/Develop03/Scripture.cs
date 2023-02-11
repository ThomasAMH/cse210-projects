public class Scripture {

    public string FullReference;
    public List<Verse> fullScripture = new List<Verse>();
    public Scripture(string bookName, int chapterNumber, int verseNumber) {
        Console.WriteLine("Enter the text of the verse:");
        string verseText = Console.ReadLine();
        Verse userVerse = new Verse(bookName, chapterNumber, verseNumber, verseText);
        fullScripture.Add(userVerse);
        FullReference = bookName + " " + chapterNumber.ToString() + ":" + verseNumber.ToString();
    }
    public Scripture(string bookName, int chapterNumber, int startVerse, int endVerse) {
        string verseText;

        for (int i = 0; i <= (endVerse - startVerse); i++) {
            Console.WriteLine($"Enter the text of verse: {startVerse + i}");
            verseText = Console.ReadLine();
            Verse userVerse = new Verse(bookName, chapterNumber, startVerse+i, verseText);
            fullScripture.Add(userVerse);
    }
    FullReference = bookName + " " + chapterNumber.ToString() + ":" + startVerse.ToString() + "-" + endVerse.ToString();
}
}