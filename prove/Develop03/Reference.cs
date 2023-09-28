public class Reference 
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference()
    {
        _book = "John";
        _chapter = 3;
        _startVerse = 16;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetReference()
    {
        string versesString = "";
        if (_endVerse == null || _endVerse == 0)
        {
            versesString = $"{_startVerse}";
        }
        else 
        {
            versesString = $"{_startVerse}-{_endVerse}";
        }
        return $"{_book} {_chapter}:{versesString}";
    }
}