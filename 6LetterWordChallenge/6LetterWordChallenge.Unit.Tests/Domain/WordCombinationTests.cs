using _6LetterWordChallenge.Domain.Words.Models;
using FluentAssertions;
using Xunit;

namespace _6LetterWordChallenge.Unit.Tests.Domain;

public class WordCombinationTests
{
    [Fact]
    public void Constructor_WhenValidWords_ShouldSetTextProperty()
    {
        // Arrange
        var firstWord = "app";
        var secondWord = "le";

        // Act
        var combination = new WordCombination(firstWord, secondWord);

        // Assert
        combination.Text.Should().Be("app+le=apple");
    }
}