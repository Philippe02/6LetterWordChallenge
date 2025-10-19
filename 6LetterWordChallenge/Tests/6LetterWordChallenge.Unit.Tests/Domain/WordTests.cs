using _6LetterWordChallenge.Domain.Words.Models;
using FluentAssertions;
using Xunit;

namespace _6LetterWordChallenge.Unit.Tests.Domain;

public class WordTests
{
    [Fact]
    public void Should_Create_Word()
    {
        // Arrange
        var text = "hello";

        // Act
        var word = new Word(text);

        // Assert
        word.Text.Should().Be(text);
    }
    
    [Fact]
    public void Given_Two_Identical_Words_Equals_Should_Return_True()
    {
        // Arrange
        var word1 = new Word("test");
        var word2 = new Word("test");

        // Act & Assert
        word1.Equals(word2).Should().BeTrue();
        word2.Equals(word1).Should().BeTrue();
    }

    [Fact]
    public void Given_Two_Different_Words_Equals_Should_Return_False()
    {
        // Arrange
        var word1 = new Word("test");
        var word2 = new Word("different");

        // Act & Assert
        word1.Equals(word2).Should().BeFalse();
        word2.Equals(word1).Should().BeFalse();
    }
}