namespace _6LetterWordChallenge.Domain.Words.Models;

public class Word(string text) : IWord, IEquatable<Word>
{
    public string Text { get; } = text;

    public bool Equals(Word? other)
    {
        return other is not null && string.Equals(Text, other.Text, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => Text.GetHashCode();
}