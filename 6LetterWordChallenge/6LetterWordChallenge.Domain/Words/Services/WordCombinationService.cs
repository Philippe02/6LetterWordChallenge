using _6LetterWordChallenge.Domain.Words.Models;

namespace _6LetterWordChallenge.Domain.Words.Services;

public class WordCombinationService
{
    public List<WordCombination> GetWordCombinationsByLength(HashSet<Word> words, int wordLength, int combinationCount)
    {
        var results = new List<WordCombination>();
        var allWords = words.Select(w => w.Text).ToHashSet();
        
        // Group words by length to optimize search
        var wordsByLength = words
            .Where(w => w.Text.Length < wordLength)
            .GroupBy(w => w.Text.Length)
            .ToDictionary(g => g.Key, g => g.Select(w => w.Text).ToList());

        FindCombinationsRecursively(allWords, wordsByLength, results, new List<string>(), wordLength, combinationCount, 0);
        
        return results;
    }

    private void FindCombinationsRecursively(
        HashSet<string> allWords,
        Dictionary<int, List<string>> wordsByLength,
        List<WordCombination> result,
        List<string> currentCombination,
        int targetLength,
        int wordCombinations,
        int currentLength)
    {
        if (currentCombination.Count == wordCombinations)
        {
            if (currentLength == targetLength)
            {
                string combinedWord = string.Concat(currentCombination);
                if (allWords.Contains(combinedWord))
                {
                    result.Add(new WordCombination(new List<string>(currentCombination)));
                }
            }
            return;
        }

        int remainingLength = targetLength - currentLength;
        int remainingWordCombinations = wordCombinations - currentCombination.Count;
        
        // Ensure we leave room for remaining words
        // This guarantees at least 1 character for each remaining word
        int maxWordLength = remainingLength - (remainingWordCombinations - 1);
        
        for (int len = 1; len <= maxWordLength; len++)
        {
            if (wordsByLength.ContainsKey(len))
            {
                foreach (var word in wordsByLength[len])
                {
                    currentCombination.Add(word);
                    FindCombinationsRecursively(allWords, wordsByLength, result, currentCombination, targetLength, wordCombinations, currentLength + len);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }
    }
}