namespace _6LetterWordChallenge.Domain.Words.Models;

public class WordCombination : IWord
{
    public WordCombination(List<string> words)
    {
        var joinedParts = string.Join("+", words);
        var combinedWord = string.Concat(words);
        Text = $"{joinedParts}={combinedWord}";
    }
    public string Text { get; }
}