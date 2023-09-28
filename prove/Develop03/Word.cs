public class Word 
{
    private string _word;

    public void RemovedWord()
    {
        var length = _word.Length;
        var newStr = "";
        for (int i = 0; i < length; i++)
        {
           newStr += "_";
        }
        _word = newStr;
    }

    public string GetDisplayedText()
    {
        return _word;
    }

    public bool IsHidden()
    {
        bool isHidden = true;
        List<char> chars = new List<char>();
        chars.AddRange(_word);
        foreach(char c in chars)
        {
            if (c.ToString() != "_")
            {
                isHidden = false;
                break;
            }
        }
        return isHidden;
    }

    public void SetWord(string word)
    {
        _word = word;
    }
}