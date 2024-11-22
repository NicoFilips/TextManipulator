using System.Text.RegularExpressions;
using TextManipulator.Repository;

class Program
{
    static void Main()
    {
        Dictionary<string, string> sampleWords =
            SampleWordsRepository.ParseTextFile("C:\\Users\\busin\\Desktop\\Neuer Ordner\\Austauschliste.txt");
        string text = TextRepository.ReadTextFromFile("C:\\Users\\busin\\Desktop\\Neuer Ordner\\Textbeispiel.txt");

        text = SearchTextRepository.ReplaceMatchesInText(text, sampleWords);

        TextRepository.WriteTextToFile("C:\\Users\\busin\\Desktop\\Neuer Ordner\\Textbeispiel.txt", text);
    }
}