namespace _6LetterWordChallenge.Domain.Words.Models;

public class WordCombination(string firstWord, string secondWord) : IWord
{
    public string Text { get; } = $"{firstWord}+{secondWord}={firstWord + secondWord}";
}