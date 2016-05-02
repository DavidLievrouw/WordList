using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using WordList.Output;
using WordList.Processing;

namespace WordList.Tests {
  [TestFixture]
  public class WordListProgramTests {
    IWordListReader _wordListReader;
    IWordCombinationFinder _wordCombinationFinder;
    IWordCombinationsOutputWriter _outputWriter;
    WordListProgram _sut;

    [SetUp]
    public virtual void SetUp() {
      _wordListReader = A.Fake<IWordListReader>();
      _wordCombinationFinder = A.Fake<IWordCombinationFinder>();
      _outputWriter = A.Fake<IWordCombinationsOutputWriter>();
      _sut = new WordListProgram(_wordListReader, _wordCombinationFinder, _outputWriter);
    }

    [TestFixture]
    public class Construction : WordListProgramTests {
      [Test]
      public void GivenNullWordListReader_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListProgram(null, _wordCombinationFinder, _outputWriter));
      }

      [Test]
      public void GivenNullWordCombinationFinder_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListProgram(_wordListReader, null, _outputWriter));
      }

      [Test]
      public void GivenNullOutputWriter_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListProgram(_wordListReader, _wordCombinationFinder, null));
      }
    }

    [TestFixture]
    public class Run : WordListProgramTests {
      IEnumerable<Word> _allWords;
      IEnumerable<WordCombination> _foundCombinations;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _allWords = A.Fake<IEnumerable<Word>>();
        _foundCombinations = A.Fake<IEnumerable<WordCombination>>();
      }

      [Test]
      public void WritesFoundCombinationsFromReadWords() {
        A.CallTo(() => _wordListReader.ReadWordList()).Returns(_allWords);
        A.CallTo(() => _wordCombinationFinder.FindCombinations(_allWords)).Returns(_foundCombinations);

        _sut.Run();

        A.CallTo(() => _outputWriter.Write(_foundCombinations)).MustHaveHappened();
      }
    }
  }
}