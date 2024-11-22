namespace TextManipulator.Repository;

public class TextRepository
{
    public static string ReadTextFromFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Einlesen der Datei: {ex.Message}");
            return string.Empty;
        }
    }
    
    public static void WriteTextToFile(string filePath, string text)
    {
        try
        {
            File.WriteAllText(filePath, text);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Schreiben der Datei: {ex.Message}");
        }
    }
}