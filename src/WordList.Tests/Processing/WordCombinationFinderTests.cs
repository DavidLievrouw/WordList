using System;
using System.Linq;
using NUnit.Framework;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordCombinationFinderTests {
    int _desiredLength;
    WordCombinationFinder _sut;

    [SetUp]
    public virtual void SetUp() {
      _desiredLength = 6;
      _sut = new WordCombinationFinder(_desiredLength);
    }

    [TestFixture]
    public class Construction : WordCombinationFinderTests {
      [TestCase(0)]
      [TestCase(-1)]
      [TestCase(int.MinValue)]
      public void GivenInvalidDesiredLength_Throws(int invalidDesiredLength) {
        Assert.Throws<ArgumentOutOfRangeException>(() => new WordCombinationFinder(invalidDesiredLength));
      }
    }

    [TestFixture]
    public class FindCombinations : WordCombinationFinderTests {
      [Test]
      public void GivenNullWords_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.FindCombinations(null));
      }

      [Test]
      public void GivenWordList_FindsValidCombinations() {
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
          new WordCombination(new Word("al"), new Word("bums")),
          new WordCombination(new Word("be"), new Word("foul"))
        };

        var actual = _sut.FindCombinations(allWords);
        Assert.That(actual, Is.EquivalentTo(validCombinations));
      }

      [Test]
      public void GivenWordListWithoutWordsOfDesiredLength_ReturnsEmptyResult() {
        var allWords = new[] {
          new Word("al"),
          new Word("u"),
          new Word("foul"),
          new Word("be"),
          new Word("magazine"),
          new Word("bums"),
          new Word("trump")
        };

        var actual = _sut.FindCombinations(allWords).ToList();

        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.Empty);
      }

      [Test]
      public void GivenWordList_ReturnsDistinctValidCombinations() {
        var allWords = new[] {
          new Word("albums"),
          new Word("al"),
          new Word("bums"),
          new Word("albums"),
          new Word("a"),
          new Word("lbums"),
          new Word("al"),
          new Word("bums")
        };
        var validCombinations = new[] {
          new WordCombination(new Word("al"), new Word("bums")),
          new WordCombination(new Word("a"), new Word("lbums"))
        };

        var actual = _sut.FindCombinations(allWords);
        Assert.That(actual, Is.EquivalentTo(validCombinations));
      }
    }
  }
}