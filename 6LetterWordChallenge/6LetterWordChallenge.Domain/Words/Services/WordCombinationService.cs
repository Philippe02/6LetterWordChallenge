using _6LetterWordChallenge.Domain.Words.Models;

namespace _6LetterWordChallenge.Domain.Words.Services;

public class WordCombinationService
{
    public List<WordCombination> GetWordCombinationsByLength(HashSet<Word> words, int wordLength)
    {
        var list = new List<WordCombination>();
        foreach (var word1 in words)
        {
            foreach (var word2 in words)
            {
                if (word1.Text.Length + word2.Text.Length == wordLength)
                {
                    var combination = new Word($"{word1.Text}{word2.Text}");
                    if (words.Contains(combination))
                    {
                        list.Add(new WordCombination(word1.Text, word2.Text));   
                    }
                }
            }
        }

        return list;
    } 
}