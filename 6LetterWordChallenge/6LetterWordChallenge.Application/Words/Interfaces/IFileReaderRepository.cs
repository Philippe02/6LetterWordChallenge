using _6LetterWordChallenge.Domain.Words.Models;

namespace _6LetterWordChallenge.Application.Words.Interfaces;

public interface IFileReaderRepository
{
    Task<HashSet<Word>> GetWordsAsHashSetAsync(string fileName, CancellationToken cancellationToken);
}