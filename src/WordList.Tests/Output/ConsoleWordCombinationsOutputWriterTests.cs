using System;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using WordList.Output;
using WordList.Processing;

namespace WordList.Tests.Output {
  [TestFixture]
  public class ConsoleWordCombinationsOutputWriterTests {
    IConsole _console;
    ConsoleWordCombinationsOutputWriter _sut;

    [SetUp]
    public virtual void SetUp() {
      _console = A.Fake<IConsole>();
      _sut = new ConsoleWordCombinationsOutputWriter(_console);
    }

    [TestFixture]
    public class Construction : ConsoleWordCombinationsOutputWriterTests {
      [Test]
      public void GivenNullConsole_Throws() {
        Assert.Throws<ArgumentNullException>(() => new ConsoleWordCombinationsOutputWriter(null));
      }
    }

    [TestFixture]
    public class Write : ConsoleWordCombinationsOutputWriterTests {
      [Test]
      public void GivenNullWords_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.Write(null));
      }

      [Test]
      public void WhenNoCombinationsAreSpecified_WritesNoneFoundMessageToConsole() {
        const string noCombinationsFoundMessage = "No combinations found";
        _sut.Write(Enumerable.Empty<WordCombination>());
        A.CallTo(() => _console.WriteLine(noCombinationsFoundMessage)).MustHaveHappened();
      }

      [Test]
      public void WritesEverySpecifiedCombinationToConsole() {
        var foundCombinations = new[] {
          new WordCombination(new Word("Left1"), new Word("Right1")),
          new WordCombination(new Word("Left2"), new Word("Right3")),
          new WordCombination(new Word("Left2"), new Word("Right3")),
        };

        _sut.Write(foundCombinations);

        foundCombinations.ForEach(combination => A.CallTo(() => _console.WriteLine(combination.ToString())).MustHaveHappened());
      }
    }
  }
}