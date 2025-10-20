using _6LetterWordChallenge.Application.Words.Dtos;
using _6LetterWordChallenge.Application.Words.Interfaces;
using _6LetterWordChallenge.Domain.Words.Services;
using FluentValidation;
using MediatR;

namespace _6LetterWordChallenge.Application.Words.Queries;

public class GetWordCombinationsQuery(string fileName, int wordLength, int wordCombinations) : IRequest<WordCombinationsDto>
{
    public string FileName { get; } = fileName;
    public int WordLength { get; } = wordLength;
    public int WordCombinations { get; } = wordCombinations;
}

internal class GetWordCombinationsQueryHandler(IFileReaderRepository fileReaderRepository, WordCombinationService wordCombinationService) : IRequestHandler<GetWordCombinationsQuery, WordCombinationsDto>
{
    public async Task<WordCombinationsDto> Handle(GetWordCombinationsQuery request, CancellationToken cancellationToken)
    {
        if (!File.Exists(request.FileName))
        {
            throw new FileNotFoundException($"File {request.FileName} not found.");
        }
        
        var words = await fileReaderRepository.GetWordsAsHashSetAsync(request.FileName, cancellationToken);
        var wordCombinations = wordCombinationService.GetWordCombinationsByLength(words, request.WordLength, request.WordCombinations);
        
        return new WordCombinationsDto(wordCombinations, words.Count);
    }
}

public class GetWordCombinationsQueryValidator : AbstractValidator<GetWordCombinationsQuery>
{
    public GetWordCombinationsQueryValidator()
    {
        RuleFor(query => query.FileName)
            .NotEmpty();
        
        RuleFor(query => query.WordLength)
            .GreaterThan(0);
        
        RuleFor(query => query.WordCombinations)
            .GreaterThan(0);
    }
}