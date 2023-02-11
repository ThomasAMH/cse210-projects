public class TestClass {

    public TestClass() {
        Console.WriteLine("Available Tests:");
        Console.WriteLine("1: Test Verse Struct");
        Console.WriteLine("2: Test Add Scripture");
        int userInt;

        userInt = int.Parse(Console.ReadLine());

        switch (userInt) {
            case 1:
                TestVerseStruct(); break;
        }
    }
    private void TestVerseStruct() {
        string userBookName;
        int userChapterNumber;
        int userVerseNumber;
        string userVerse;
        
        Console.WriteLine("userBookName:");
        userBookName = Console.ReadLine();

        Console.WriteLine("userChapterNumber:");
        userChapterNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("userVerseNumber:");
        userVerseNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("userVerse:");
        userVerse = Console.ReadLine();

        Verse TestVerse = new Verse(userBookName, userChapterNumber, userVerseNumber, userVerse);

        //Expecting Book 1:1
        Console.WriteLine(TestVerse.FullReference);

        //Expecting Book | 1 | 1
        Console.WriteLine($"{TestVerse.BookName}"+" | "+$"{TestVerse.ChapterNumber.ToString()}"+" | "+$"{TestVerse.VerseNumber.ToString()}");
    }

    private void TestAddScripture() {
        
    }
}