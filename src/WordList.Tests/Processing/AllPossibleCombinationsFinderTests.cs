using System;
using System.Linq;
using NUnit.Framework;

namespace WordList.Processing {
  [TestFixture]
  public class AllPossibleCombinationsFinderTests {
    AllPossibleCombinationsFinder _sut;
    int _desiredLength;
    IWordsIndex _wordsIndex;
    Word[] _allWords;

    [SetUp]
    public void SetUp() {
      _desiredLength = 6;
      _allWords = new[] {
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
      _wordsIndex = new FakeWordsIndex(_allWords);
      _sut = new AllPossibleCombinationsFinder();
    }

    [TestFixture]
    public class FindAllPossibleCombinationsOfLength : AllPossibleCombinationsFinderTests {
      [Test]
      public void GivenNullWordsIndex_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.FindAllPossibleCombinationsOfLength(null, _desiredLength));
      }

      [TestCase(0)]
      [TestCase(-1)]
      [TestCase(int.MinValue)]
      public void GivenInvalidDesiredLength_Throws(int invalidDesiredLength) {
        Assert.Throws<ArgumentOutOfRangeException>(() => _sut.FindAllPossibleCombinationsOfLength(_wordsIndex, invalidDesiredLength));
      }

      [Test]
      public void IfNoValidCombinationsExist_ReturnsEmptyResult() {
        _wordsIndex = new FakeWordsIndex(Enumerable.Empty<Word>());
        var actual = _sut.FindAllPossibleCombinationsOfLength(_wordsIndex, _desiredLength).ToList();
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.Empty);
      }

      [Test]
      public void ReturnsAllPossibleCombinations() {
        var expectedCombinations = new[] {
          new WordCombination(new Word("al"), new Word("bums")),
          new WordCombination(new Word("be"), new Word("foul")),
          new WordCombination(new Word("al"), new Word("foul")),
          new WordCombination(new Word("be"), new Word("bums")),
          new WordCombination(new Word("u"), new Word("trump")),
          new WordCombination(new Word("bums"), new Word("al")),
          new WordCombination(new Word("foul"), new Word("be")),
          new WordCombination(new Word("foul"), new Word("al")),
          new WordCombination(new Word("bums"), new Word("be")),
          new WordCombination(new Word("trump"), new Word("u"))
        };

        var actual = _sut.FindAllPossibleCombinationsOfLength(_wordsIndex, _desiredLength);

        Assert.That(actual, Is.EquivalentTo(expectedCombinations));
      }
    }
  }
}