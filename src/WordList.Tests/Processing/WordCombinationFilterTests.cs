using System;
using System.Linq;
using NUnit.Framework;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordCombinationFilterTests {
    WordCombinationFilter _sut;
    WordCombination[] _validCombinations;
    Word[] _wordsWithDesiredLength;
    WordCombination[] _expectedCombinations;

    [SetUp]
    public void SetUp() {
      _validCombinations = new[] {
        new WordCombination(new Word("al"), new Word("bums")),
        new WordCombination(new Word("bums"), new Word("al")),
        new WordCombination(new Word("be"), new Word("foul")),
        new WordCombination(new Word("al"), new Word("bums"))
      };
      _wordsWithDesiredLength = new[] {
        new Word("albums"),
        new Word("befoul")
      };
      _expectedCombinations = _validCombinations.Where(c => _wordsWithDesiredLength.Select(w => w.Value).Contains(c.Value)).ToArray();
      _sut = new WordCombinationFilter();
    }

    [TestFixture]
    public class FilterByListOfPossibleWords : WordCombinationFilterTests {
      [Test]
      public void GivenNullCombinations_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.FilterByListOfPossibleWords(null, _wordsWithDesiredLength));
      }

      [Test]
      public void GivenNullWords_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.FilterByListOfPossibleWords(_validCombinations, null));
      }

      [Test]
      public void WhenNoCombinationsAreFound_ReturnsEmptyResult() {
        var actual = _sut.FilterByListOfPossibleWords(_validCombinations, Enumerable.Empty<Word>()).ToList();
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.Empty);
      }

      [Test]
      public void OnlyReturnsCombinations_ThatAreSpecifiedInTheList() {
        var actual = _sut.FilterByListOfPossibleWords(_validCombinations, _wordsWithDesiredLength);
        Assert.That(actual, Is.EquivalentTo(_expectedCombinations));
      }
    }
  }
}