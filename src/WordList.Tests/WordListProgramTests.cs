using System;
using System.Collections.Generic;
using System.IO;
using FakeItEasy;
using NUnit.Framework;
using WordList.Output;
using WordList.Processing;

namespace WordList {
  [TestFixture]
  public class WordListProgramTests {
    IWordListReaderFactory _wordListReaderFactory;
    IWordCombinationFinderFactory _wordCombinationFinderFactory;
    IWordCombinationsOutputWriter _outputWriter;
    ProgramSettings _settings;
    WordListProgram _sut;

    [SetUp]
    public virtual void SetUp() {
      _wordListReaderFactory = A.Fake<IWordListReaderFactory>();
      _wordCombinationFinderFactory = A.Fake<IWordCombinationFinderFactory>();
      _outputWriter = A.Fake<IWordCombinationsOutputWriter>();
      _settings = new ProgramSettings {
        DesiredWordLength = 8,
        WordListFile = new FileInfo("C:\\Windows\\WordList.ini")
      };
      _sut = new WordListProgram(_wordListReaderFactory, _wordCombinationFinderFactory, _outputWriter, _settings);
    }

    [TestFixture]
    public class Construction : WordListProgramTests {
      [Test]
      public void GivenNullWordListReader_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListProgram(null, _wordCombinationFinderFactory, _outputWriter, _settings));
      }

      [Test]
      public void GivenNullWordCombinationFinder_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListProgram(_wordListReaderFactory, null, _outputWriter, _settings));
      }

      [Test]
      public void GivenNullOutputWriter_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListProgram(_wordListReaderFactory, _wordCombinationFinderFactory, null, _settings));
      }

      [Test]
      public void GivenNullSettings_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListProgram(_wordListReaderFactory, _wordCombinationFinderFactory, _outputWriter, null));
      }
    }

    [TestFixture]
    public class Run : WordListProgramTests {
      IEnumerable<Word> _allWords;
      IEnumerable<WordCombination> _foundCombinations;
      IWordListReader _wordListReader;
      IWordCombinationFinder _wordCombinationFinder;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _allWords = A.Fake<IEnumerable<Word>>();
        _foundCombinations = A.Fake<IEnumerable<WordCombination>>();
        _wordListReader = A.Fake<IWordListReader>();
        _wordCombinationFinder = A.Fake<IWordCombinationFinder>();
      }

      [Test]
      public void WritesFoundCombinationsFromReadWords() {
        A.CallTo(() => _wordListReaderFactory.Create(_settings)).Returns(_wordListReader);
        A.CallTo(() => _wordCombinationFinderFactory.Create(_settings)).Returns(_wordCombinationFinder);

        A.CallTo(() => _wordListReader.ReadWordList()).Returns(_allWords);
        A.CallTo(() => _wordCombinationFinder.FindCombinations(_allWords)).Returns(_foundCombinations);

        _sut.Run();

        A.CallTo(() => _outputWriter.Write(_foundCombinations)).MustHaveHappened();
      }
    }
  }
}