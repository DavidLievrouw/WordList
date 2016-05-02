using System;
using NUnit.Framework;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordsWithDesiredLengthFinderTests {
    int _desiredLength;
    WordsWithDesiredLengthFinder _sut;

    [SetUp]
    public virtual void SetUp() {
      _desiredLength = 6;
      _sut = new WordsWithDesiredLengthFinder(_desiredLength);
    }

    [TestFixture]
    public class Construction : WordsWithDesiredLengthFinderTests {
      [TestCase(0)]
      [TestCase(-1)]
      [TestCase(int.MinValue)]
      public void GivenInvalidDesiredLength_Throws(int invalidDesiredLength) {
        Assert.Throws<ArgumentOutOfRangeException>(() => new WordsWithDesiredLengthFinder(invalidDesiredLength));
      }
    }

    [TestFixture]
    public class FindWordsWithDesiredLength : WordsWithDesiredLengthFinderTests {
      [Test]
      public void GivenNullWords_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.FindWordsWithDesiredLength(null));
      }

      [Test]
      public void GivenWordListWithoutValidEntry_ReturnsEmptyResult() {
        var allWords = new[] {
          new Word("al"),
          new Word("u"),
          new Word("foul"),
          new Word("be"),
          new Word("magazine"),
          new Word("bums"),
          new Word("trump")
        };
        var actual = _sut.FindWordsWithDesiredLength(allWords);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.Empty);
      }

      [Test]
      public void GivenWordList_FindsWordsWithDesiredLength() {
        var allWords = new[] {
          new Word("albums"),
          new Word("al"),
          new Word("u"),
          new Word("ticket"),
          new Word("foul"),
          new Word("be"),
          new Word("befoul"),
          new Word("magazine"),
          new Word("bums"),
          new Word("trump")
        };
        var validCombinations = new[] {
          new Word("albums"),
          new Word("ticket"),
          new Word("befoul")
        };

        var actual = _sut.FindWordsWithDesiredLength(allWords);
        Assert.That(actual, Is.EquivalentTo(validCombinations));
      }
    }
  }
}