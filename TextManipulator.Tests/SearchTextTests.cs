using FluentAssertions;
using NUnit.Framework;
using TextManipulator;
using TextManipulator.Repository;

namespace TextManipulator.Tests;

public sealed class SearchTextTests
{
    [TestFixture]
    public class ReplaceMatchesInTextTests
    {
        [TestCase("Dies ist ein Beispieltext mit einem SampleKey.", "Dies ist ein Beispieltext mit einem SampleValue.", "SampleKey", "SampleValue")]
        [TestCase("Das ist ein Text ohne Treffer.", "Das ist ein Text ohne Treffer.", "SampleKey", "SampleValue")]
        [TestCase("Hier steht ein andererKey, der ersetzt wird.", "Hier steht ein ersetzterValue, der ersetzt wird.", "andererKey", "ersetzterValue")]
        [TestCase("Schlüssel eins und Schlüssel zwei sind beide hier: Key1 und Key2.", "Schlüssel eins und Schlüssel zwei sind beide hier: Value1 und Value2.", "Key1", "Value1", "Key2", "Value2")]
        public void ReplaceMatchesInText_GivenTextAndDictionary_ShouldReplaceCorrectly(string inputText, string expectedText, params string[] dictionaryEntries)
        {
            // Arrange
            var dictionary = new Dictionary<string, string>();
            for (int i = 0; i < dictionaryEntries.Length; i += 2)
            {
                dictionary.Add(dictionaryEntries[i], dictionaryEntries[i + 1]);
            }

            // Act
            var result = SearchTextRepository.ReplaceMatchesInText(inputText, dictionary);

            // Assert
            result.Should().Be(expectedText);
        }
    }
}