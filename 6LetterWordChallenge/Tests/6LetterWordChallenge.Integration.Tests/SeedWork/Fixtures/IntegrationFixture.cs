using _6LetterWordChallenge.Application.Extensions;
using _6LetterWordChallenge.Infrastructure.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace _6LetterWordChallenge.Integration.Tests.SeedWork.Fixtures;

public class IntegrationFixture : IDisposable
{
    protected IServiceProvider ServiceProvider { get; }
    protected IMediator Mediator => ServiceProvider.GetRequiredService<IMediator>();

    public IntegrationFixture()
    {
        var services = new ServiceCollection();
        
        services.AddLogging();
        services.AddApplication();
        services.AddInfrastructure();
        
        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        // Clean up if needed
        if (ServiceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}