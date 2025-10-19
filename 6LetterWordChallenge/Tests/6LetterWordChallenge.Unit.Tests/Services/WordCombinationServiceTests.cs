using _6LetterWordChallenge.Domain.Words.Models;
using _6LetterWordChallenge.Domain.Words.Services;
using FluentAssertions;
using Xunit;

namespace _6LetterWordChallenge.Unit.Tests.Services;

public class WordCombinationServiceTests
{
    private readonly WordCombinationService _wordCombinationService;

    public WordCombinationServiceTests()
    {
        _wordCombinationService = new WordCombinationService();
    }

    [Fact]
    public void Given_Valid_Words_Should_Return_Correct_Combination()
    {
        // Arrange
        var words = new HashSet<Word>
        {
            new Word("app"),
            new Word("le"),
            new Word("apple"),
            new Word("tr"),
            new Word("ain"),
            new Word("train")
        };
        
        var wordLength = 5;

        // Act
        var result = _wordCombinationService.GetWordCombinationsByLength(words, wordLength);
        var appleCombination = result.Where(w => w.Text.Contains("apple")).First();
        var trainCombination = result.Where(w => w.Text.Contains("train")).First();

        // Assert
        Assert.NotNull(result);
        result.Count.Should().Be(2);
        appleCombination.Text.Should().Be("app+le=apple");
        trainCombination.Text.Should().Be("tr+ain=train");
    }
    
    [Fact]
    public void Given_Valid_Words_With_Wrong_WordLength_Parameter_Should_Return_No_Combinations()
    {
        // Arrange
        var words = new HashSet<Word>
        {
            new Word("ban"),
            new Word("ana"),
            new Word("banana")
        };
        var wordLength = 5;

        // Act
        var result = _wordCombinationService.GetWordCombinationsByLength(words, wordLength);

        // Assert
        Assert.NotNull(result);
        result.Count.Should().Be(0);
    }
    
    [Fact]
    public void Given_Valid_Words_With_No_Complete_Word_Should_Return_No_Combinations()
    {
        // Arrange
        var words = new HashSet<Word>
        {
            new Word("app"),
            new Word("le"),
            // new Word("apple"), No complete word
        };
        var wordLength = 5;

        // Act
        var result = _wordCombinationService.GetWordCombinationsByLength(words, wordLength);

        // Assert
        Assert.NotNull(result);
        result.Count.Should().Be(0);
    }
}