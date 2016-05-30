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
    public void SetUp() {
      _desiredLength = 6;
      _wordsIndexFactory = new WordsIndexFactory();
      _allPossibleCombinationsFinder = new AllPossibleCombinationsFinder();
      _wordCombinationFilter = new WordCombinationFilter();
      _sut = new WordCombinationFinder(_desiredLength, _wordsIndexFactory, _allPossibleCombinationsFinder, _wordCombinationFilter);
    }

    [TestFixture]
    public class FindCombinations : WordCombinationFinderTests {
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
    }
  }
}