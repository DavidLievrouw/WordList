using System;
using System.IO;
using FakeItEasy;
using NUnit.Framework;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordCombinationFinderFactoryTests {
    IWordsIndexFactory _wordsIndexFactory;
    IAllPossibleCombinationsFinder _allPossibleCombinationsFinder;
    IWordCombinationFilter _wordCombinationFilter;
    WordCombinationFinderFactory _sut;

    [SetUp]
    public virtual void SetUp() {
      _wordsIndexFactory = A.Fake<IWordsIndexFactory>();
      _allPossibleCombinationsFinder = A.Fake<IAllPossibleCombinationsFinder>();
      _wordCombinationFilter = A.Fake<IWordCombinationFilter>();
      _sut = new WordCombinationFinderFactory(_wordsIndexFactory, _allPossibleCombinationsFinder, _wordCombinationFilter);
    }

    [TestFixture]
    public class Construction : WordCombinationFinderFactoryTests {
      [Test]
      public void GivenNullWordsIndexFactory_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordCombinationFinderFactory(null, _allPossibleCombinationsFinder, _wordCombinationFilter));
      }

      [Test]
      public void GivenNullCombinationsFinder_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordCombinationFinderFactory(_wordsIndexFactory, null, _wordCombinationFilter));
      }

      [Test]
      public void GivenNullWordCombinationFilter_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordCombinationFinderFactory(_wordsIndexFactory, _allPossibleCombinationsFinder, null));
      }
    }

    [TestFixture]
    public class Create : WordCombinationFinderFactoryTests {
      ProgramSettings _settings;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _settings = new ProgramSettings {
          DesiredWordLength = 8,
          WordListFile = new FileInfo("C:\\Windows\\File.txt")
        };
      }

      [Test]
      public void GivenNullSettings_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.Create(null));
      }

      [TestCase(0)]
      [TestCase(-1)]
      [TestCase(int.MinValue)]
      public void GivenInvalidDesiredLength_Throws(int invalidDesiredLength) {
        _settings.DesiredWordLength = invalidDesiredLength;
        Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Create(_settings));
      }

      [Test]
      public void CreatesNewInstance() {
        var actual = _sut.Create(_settings);
        Assert.That(actual, Is.InstanceOf<IWordCombinationFinder>());
      }
    }
  }
}