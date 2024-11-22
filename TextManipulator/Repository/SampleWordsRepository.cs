namespace TextManipulator.Repository;

using System;
using System.Collections.Generic;
using System.IO;

public class SampleWordsRepository
{
    public static Dictionary<string, string> ParseTextFile(string filePath)
    {
        var dictionary = new Dictionary<string, string>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                {
                    continue;
                }

                var keyValue = line.Split(';');
                if (keyValue.Length == 2)
                {
                    var key = keyValue[0].Trim();
                    var value = keyValue[1].Trim();
                    
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, value);
                    }
                    else
                    {
                        Console.WriteLine($"Warnung: Der Schlüssel '{key}' ist mehrfach vorhanden. Nur der erste Wert wird übernommen.");
                    }
                }
                else
                {
                    Console.WriteLine($"Warnung: Ungültige Zeile ignoriert: '{line}'");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Einlesen der Datei: {ex.Message}");
        }

        return dictionary;
    }
}