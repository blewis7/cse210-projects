public class Macros : Food
{
    private double _proteinGrams;
    private double _fatGrams;
    private double _carbGrams;
    private double _proteinPercent;
    private double _fatPercent;
    private double _carbPercent;

    public Macros()
    {
        _calories = 0;
        _proteinGrams = 0;
        _proteinPercent = 0;
        _fatGrams = 0;
        _fatPercent = 0;
        _carbGrams = 0;
        _carbPercent = 0;
    }

    public double GetProteinPercent()
    {
        return _proteinPercent;
    }
    public string GetProteinPercentString()
    {
        return $"{_proteinPercent}%";
    }

    public double GetProteinGrams()
    {
        return _proteinGrams;
    }
    public double GetFatPercent()
    {
        return _fatPercent;
    }
    public string GetFatPercentString()
    {
        return $"{_fatPercent}%";
    }

    public double GetFatGrams()
    {
        return _fatGrams;
    }
    public double GetCarbPercent()
    {
        return _carbPercent;
    }
    public string GetCarbPercentString()
    {
        return $"{_carbPercent}%";
    }

    public double GetCarbGrams()
    {
        return _carbGrams;
    }
    public void SetProteinPercent(double percent)
    {
        _proteinPercent = percent;
    }

    public void SetProteinGrams(double grams)
    {
        _proteinGrams = grams;
    }
    public void SetFatPercent(double percent)
    {
        _fatPercent = percent;
    }

    public void SetFatGrams(double grams)
    {
        _fatGrams = grams;
    }
    public void SetCarbPercent(double percent)
    {
        _carbPercent = percent;
    }

    public void SetCarbGrams(double grams)
    {
        _carbGrams = grams;
    }

    public void SetAllPercent(double protein, double fat, double carb)
    {
        _proteinPercent = protein;
        _fatPercent = fat;
        _carbPercent = carb;
    }

    public void SetAllGrams(double protein, double fat, double carb)
    {
        _proteinGrams = protein;
        _fatGrams = fat;
        _carbGrams = carb;
    }

    public void AddAllGrams(double protein, double fat, double carb)
    {
        _proteinGrams += protein;
        _fatGrams += fat;
        _carbGrams += carb;
    }

    public void SetAllPercentFromGrams()
    {
        _proteinPercent = _proteinGrams * 4 / _calories * 100;
        _carbPercent = _carbGrams * 4 / _calories * 100;
        _fatPercent = _fatGrams * 9 / _calories * 100;
    }

    public void SetAllGramsFromPercent()
    {
        _proteinGrams = _calories * (_proteinPercent / 100) / 4;
        _carbGrams = _calories * (_carbPercent / 100) / 4;
        _fatGrams = _calories * (_fatPercent / 100) / 9;
    }

    public List<string> DisplayMacrosAsStrings()
    {
        string fatString = $"Fat:{_fatGrams}|{_fatPercent}";
        string proteinString = $"Protein:{_proteinGrams}|{_proteinPercent}";
        string carbString = $"Carbs:{_carbGrams}|{_carbPercent}";

        List<string> strings = new List<string>{ proteinString, fatString, carbString };
        return strings;
    }
    // public void GetMacrosFromString(string str)
    // {
    //     string currentLine = str;
    //     int index = currentLine.IndexOf(":");
    //     int pipeIndex = currentLine.IndexOf("|");

    //     double grams = Convert.ToDouble(currentLine.Substring(index + 1, pipeIndex - index - 1));
    //     double percent = Convert.ToDouble(currentLine.Substring(pipeIndex + 1));
    // }
}