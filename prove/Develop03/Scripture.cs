public class Scripture
{
    private Reference _reference;
    private List<Word> _unalteredWords;
    private List<Word> _words;

    public Scripture()
    {
        _reference = new Reference();
        _words = GetListOfWordsFromString("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        _unalteredWords = GetListOfWordsFromString("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
    }

    public Scripture(Reference reference, string quote)
    {
        _reference = reference;
        _words = GetListOfWordsFromString(quote);
        _unalteredWords = GetListOfWordsFromString(quote);
    }

    public void DisplayScripture()
    {
        string scripture = "";
        foreach(Word word in _words)
        {
            scripture += $"{word.GetDisplayedText()} ";
        }

        Console.WriteLine(scripture.Trim());
    }

    public void DisplayUnalteredScripture()
    {
        string scripture = "";
        foreach(Word word in _unalteredWords)
        {
            scripture += $"{word.GetDisplayedText()} ";
        }

        Console.WriteLine(scripture.Trim());
    }

    public void DisplayReference()
    {
        Console.WriteLine(_reference.GetReference());
    }

    public bool IsCompletelyHidden()
    {
        bool isCompletelyHidden = true;
        foreach(Word word in _words)
        {
            if (!word.IsHidden())
            {
                isCompletelyHidden = false;
                break;
            }
        }
        return isCompletelyHidden;
    }

    public int GetNumberOfWords()
    {
        return _words.Count;
    }

    public void RemoveWordByIndex(int index)
    {
        _words[index].RemovedWord();
    }

    public List<Word> GetListOfWordsFromString(string quote)
    {
        List<Word> words = new List<Word>();
        string[] arr = quote.Split(" ");
        List<string> list = new List<string>(arr);
        foreach(string item in list)
        {
            Word word = new Word();
            word.SetWord(item);
            words.Add(word);
        }
        return words;
    }
}