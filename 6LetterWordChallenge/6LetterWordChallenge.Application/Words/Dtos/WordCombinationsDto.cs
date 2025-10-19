using _6LetterWordChallenge.Domain.Words.Models;

namespace _6LetterWordChallenge.Application.Words.Dtos;

public class WordCombinationsDto(List<WordCombination> wordCombinations, int originalWordCount)
{
    public List<WordCombination> WordCombinations { get; } = wordCombinations;
    public int OriginalWordCount { get; } = originalWordCount;
    public int CombinationWordCount { get; } = wordCombinations.Count;
}