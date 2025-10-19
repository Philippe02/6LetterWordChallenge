using _6LetterWordChallenge.Application.Words.Interfaces;
using _6LetterWordChallenge.Infrastructure.Words.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace _6LetterWordChallenge.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IFileReaderRepository, FileReaderRepository>();
    }
}