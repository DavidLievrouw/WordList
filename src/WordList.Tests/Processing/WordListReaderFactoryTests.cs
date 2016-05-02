using System;
using System.IO;
using FakeItEasy;
using NUnit.Framework;
using WordList.Data;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordListReaderFactoryTests {
    IFileReader _fileReader;
    WordListReaderFactory _sut;

    [SetUp]
    public virtual void SetUp() {
      _fileReader = A.Fake<IFileReader>();
      _sut = new WordListReaderFactory(_fileReader);
    }

    [TestFixture]
    public class Construction : WordListReaderFactoryTests {
      [Test]
      public void GivenNullFileReader_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListReaderFactory(null));
      }
    }

    [TestFixture]
    public class Create : WordListReaderFactoryTests {
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

      [Test]
      public void CreatesNewInstance() {
        var actual = _sut.Create(_settings);
        Assert.That(actual, Is.InstanceOf<IWordListReader>());
      }
    }
  }
}