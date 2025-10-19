using _6LetterWordChallenge.Application.Words.Queries;
using _6LetterWordChallenge.Integration.Tests.SeedWork.Fixtures;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace _6LetterWordChallenge.Integration.Tests.Application.Words.Queries;

public class GetWordCombinationsQueryIntegrationTests : IntegrationFixture
{
    private readonly string _testFileName = "test.txt";
    
    [Fact]
    public async Task Should_Return_Correct_Combinations()
    {
        // Arrange
        var appleWordLength = 5;
        var bananaWordLength = 6;
        var combinedAppleWord = "app+le=apple";
        var combinedBananaWord = "ba+nana=banana";
        
        var appleQuery = new GetWordCombinationsQuery(_testFileName, appleWordLength);
        var bananaQuery = new GetWordCombinationsQuery(_testFileName, bananaWordLength);

        // Act
        var appleResult = await Mediator.Send(appleQuery);
        var bananaResult = await Mediator.Send(bananaQuery);
        
        var appleCombinations = appleResult.WordCombinations;
        var bananaCombinations = bananaResult.WordCombinations;
        
        // Assert
        appleResult.Should().NotBeNull();
        bananaResult.Should().NotBeNull();
        
        appleCombinations.Should().Contain(c => c.Text.Equals(combinedAppleWord));
        bananaCombinations.Should().Contain(c => c.Text.Equals(combinedBananaWord));
    }
    
    [Fact]
    public async Task Given_Big_WordLength_Should_Return_No_Combinations()
    {
        // Arrange
        var query = new GetWordCombinationsQuery(_testFileName, 500000);

        // Act
        var result = await Mediator.Send(query);
        
        // Assert
        result.Should().NotBeNull();
        result.WordCombinations.Count.Should().Be(0);
    }
    
    [Fact]
    public async Task Given_Invalid_FileName_Should_Throw_FileNotFoundException()
    {
        // Arrange
        var query = new GetWordCombinationsQuery("invalidTestFileName.txt", 5);

        // Act
        var action = async () => await Mediator.Send(query);
        
        // Assert
        await action.Should().ThrowAsync<FileNotFoundException>();
    }
    
    [Fact]
    public async Task Given_Empty_FileName_Should_Throw_FluentVallidationException()
    {
        // Arrange
        var query = new GetWordCombinationsQuery("", 5);

        // Act
        var action = async () => await Mediator.Send(query);
        
        // Assert
        await action.Should().ThrowAsync<ValidationException>();
    }
    
    [Fact]
    public async Task Given_Invalid_WordLength_Should_Throw_FluentValidationException()
    {
        // Arrange
        var query = new GetWordCombinationsQuery(_testFileName, 0);

        // Act
        var action = async () => await Mediator.Send(query);
        
        // Assert
        await action.Should().ThrowAsync<ValidationException>();
    }
}