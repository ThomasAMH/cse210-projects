public readonly struct Verse {
    public string BookName {get; init;}
    public int ChapterNumber {get; init;}
    public int VerseNumber {get; init;}
    public string VerseText {get; init;}
    public string FullReference {get; init;}

    public Verse(string userBookName, int userChapterNumber, int userVerseNumber, string userVerseText)
    {
        BookName = userBookName;
        ChapterNumber = userChapterNumber;
        VerseNumber = userVerseNumber;
        VerseText = userVerseText;
        FullReference = BookName + " " +ChapterNumber.ToString() + ":" + VerseNumber.ToString();
    }
}