using _6LetterWordChallenge.Application.PipelineBehaviours;
using _6LetterWordChallenge.Domain.Words.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace _6LetterWordChallenge.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
        });
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
        
        services.AddScoped<WordCombinationService>();
    }
}