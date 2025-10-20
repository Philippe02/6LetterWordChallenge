using _6LetterWordChallenge.Domain.Words.Models;
using FluentAssertions;
using Xunit;

namespace _6LetterWordChallenge.Unit.Tests.Domain;

public class WordCombinationTests
{
    [Fact]
    public void Constructor_WithTwoWords_ShouldFormatTextCorrectly()
    {
        // Arrange
        var words = new List<string> { "app", "le" };

        // Act
        var combination = new WordCombination(words);

        // Assert
        combination.Text.Should().Be("app+le=apple");
    }

    [Fact]
    public void Constructor_WithThreeWords_ShouldFormatTextCorrectly()
    {
        // Arrange
        var words = new List<string> { "a", "pp", "le" };

        // Act
        var combination = new WordCombination(words);

        // Assert
        combination.Text.Should().Be("a+pp+le=apple");
    }
}