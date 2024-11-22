using System.Text.RegularExpressions;

namespace TextManipulator.Repository;

public class SearchTextRepository
{
    public static string ReplaceMatchesInText(string text, Dictionary<string, string> dictionary)
    {
        foreach (var sampleWord in dictionary)
        {
            if (Regex.IsMatch(text, @"\b" + Regex.Escape(sampleWord.Key) + @"\b"))
            {
                text = Regex.Replace(text, @"\b" + Regex.Escape(sampleWord.Key) + @"\b", sampleWord.Value);
                Console.WriteLine(
                    $"Das Wort '{sampleWord.Key}' wurde im Text gefunden und durch '{sampleWord.Value}' ersetzt.");
            }
        }

        return text;
    }
}