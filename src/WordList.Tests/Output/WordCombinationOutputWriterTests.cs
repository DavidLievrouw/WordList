using System;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using WordList.Output;
using WordList.Processing;

namespace WordList.Tests.Output {
  [TestFixture]
  public class WordCombinationOutputWriterTests {
    IConsole _console;
    WordCombinationOutputWriter _sut;

    [SetUp]
    public virtual void SetUp() {
      _console = A.Fake<IConsole>();
      _sut = new WordCombinationOutputWriter(_console);
    }

    [TestFixture]
    public class Construction : WordCombinationOutputWriterTests {
      [Test]
      public void GivenNullConsole_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordCombinationOutputWriter(null));
      }
    }

    [TestFixture]
    public class OutputWordCombinations : WordCombinationOutputWriterTests {
      [Test]
      public void GivenNullWords_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.OutputWordCombinations(null));
      }

      [Test]
      public void WhenNoCombinationsAreSpecified_WritesNoneFoundMessageToConsole() {
        const string noCombinationsFoundMessage = "No combinations found";
        _sut.OutputWordCombinations(Enumerable.Empty<WordCombination>());
        A.CallTo(() => _console.WriteLine(noCombinationsFoundMessage)).MustHaveHappened();
      }

      [Test]
      public void WritesEverySpecifiedCombinationToConsole() {
        var foundCombinations = new[] {
          new WordCombination(new Word("Left1"), new Word("Right1")),
          new WordCombination(new Word("Left2"), new Word("Right3")),
          new WordCombination(new Word("Left2"), new Word("Right3")),
        };

        _sut.OutputWordCombinations(foundCombinations);

        foundCombinations.ForEach(combination => A.CallTo(() => _console.WriteLine(combination.ToString())).MustHaveHappened());
      }
    }
  }
}