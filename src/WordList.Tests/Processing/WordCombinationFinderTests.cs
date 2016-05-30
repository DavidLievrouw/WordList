using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace WordList.Processing {
  [TestFixture]
  public class WordCombinationFinderTests {
    int _desiredLength;
    WordCombinationFinder _sut;
    IWordsIndexFactory _wordsIndexFactory;
    IAllPossibleCombinationsFinder _allPossibleCombinationsFinder;
    IWordCombinationFilter _wordCombinationFilter;

    [SetUp]
    public virtual void SetUp() {
      _desiredLength = 6;
      _wordsIndexFactory = A.Fake<IWordsIndexFactory>();
      _allPossibleCombinationsFinder = A.Fake<IAllPossibleCombinationsFinder>();
      _wordCombinationFilter = A.Fake<IWordCombinationFilter>();
      _sut = new WordCombinationFinder(_desiredLength, _wordsIndexFactory, _allPossibleCombinationsFinder, _wordCombinationFilter);
    }

    [TestFixture]
    public class Construction : WordCombinationFinderTests {
      [TestCase(0)]
      [TestCase(-1)]
      [TestCase(int.MinValue)]
      public void GivenInvalidDesiredLength_Throws(int invalidDesiredLength) {
        Assert.Throws<ArgumentOutOfRangeException>(() => new WordCombinationFinder(invalidDesiredLength, _wordsIndexFactory, _allPossibleCombinationsFinder, _wordCombinationFilter));
      }

      [Test]
      public void GivenNullWordIndexFactory_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordCombinationFinder(_desiredLength, null, _allPossibleCombinationsFinder, _wordCombinationFilter));
      }

      [Test]
      public void GivenNullAllCombinationsFinder_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordCombinationFinder(_desiredLength, _wordsIndexFactory, null, _wordCombinationFilter));
      }

      [Test]
      public void GivenNullCombinationFilter_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordCombinationFinder(_desiredLength, _wordsIndexFactory, _allPossibleCombinationsFinder, null));
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

        var wordsIndex = new FakeWordsIndex(allWords);
        A.CallTo(() => _wordsIndexFactory.Create(allWords)).Returns(wordsIndex);

        var allPossibleCombinations = new[] {
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
        A.CallTo(() => _allPossibleCombinationsFinder.FindAllPossibleCombinationsOfLength(wordsIndex, _desiredLength))
          .Returns(allPossibleCombinations);

        var validCombinations = new[] {
          new WordCombination(new Word("al"), new Word("bums")),
          new WordCombination(new Word("be"), new Word("foul"))
        };
        var wordsWithRequestedLength = wordsIndex.GetWordsOfLength(_desiredLength);
        A.CallTo(() => _wordCombinationFilter.FilterByListOfPossibleWords(allPossibleCombinations, A<IEnumerable<Word>>.That.IsSameSequenceAs(wordsWithRequestedLength)))
          .Returns(validCombinations);

        var actual = _sut.FindCombinations(allWords);
        Assert.That(actual, Is.EquivalentTo(validCombinations));
      }

      [Test]
      public void GivenWordList_ReturnsDistinctValidCombinations() {
        var validCombinations = new[] {
          new WordCombination(new Word("al"), new Word("bums")),
          new WordCombination(new Word("be"), new Word("foul")),
          new WordCombination(new Word("bums"), new Word("al")),
          new WordCombination(new Word("al"), new Word("bums"))
        };
        A.CallTo(() => _wordCombinationFilter.FilterByListOfPossibleWords(A<IEnumerable<WordCombination>>._, A<IEnumerable<Word>>._))
          .Returns(validCombinations);

        var expectedCombinations = new[] {
          new WordCombination(new Word("al"), new Word("bums")),
          new WordCombination(new Word("be"), new Word("foul")),
          new WordCombination(new Word("bums"), new Word("al"))
        };

        var actual = _sut.FindCombinations(A.Dummy<IEnumerable<Word>>());

        Assert.That(actual, Is.EquivalentTo(expectedCombinations));
      }
    }
  }
}