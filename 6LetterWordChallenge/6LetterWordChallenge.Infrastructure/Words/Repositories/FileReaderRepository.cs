using _6LetterWordChallenge.Application.Words.Interfaces;
using _6LetterWordChallenge.Domain.Words.Models;

namespace _6LetterWordChallenge.Infrastructure.Words.Repositories;

internal class FileReaderRepository : IFileReaderRepository
{
    public async Task<HashSet<Word>> GetWordsAsHashSetAsync(string fileName, CancellationToken cancellationToken)
    {
        var lines = await File.ReadAllLinesAsync(fileName, cancellationToken);
        var words = lines.Select(line => new Word(line.Trim()));
        
        return new HashSet<Word>(words);
    }
}