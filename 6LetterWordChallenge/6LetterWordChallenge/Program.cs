using _6LetterWordChallenge.Application.Extensions;
using _6LetterWordChallenge.Application.Words.Queries;
using _6LetterWordChallenge.Infrastructure.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace _6LetterWordChallenge;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        
        services.AddLogging();
        
        services.AddInfrastructure();
        services.AddApplication();
        
        var serviceProvider = services.BuildServiceProvider();
        
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        
        var query = new GetWordCombinationsQuery("input.txt", 6);
        var result = await mediator.Send(query);
        
        foreach (var combination in result.WordCombinations)
        {
            Console.Write($"{combination.Text}, ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"Original words: {result.OriginalWordCount}");
        Console.WriteLine($"Found combinations: {result.CombinationWordCount}");
    }
}