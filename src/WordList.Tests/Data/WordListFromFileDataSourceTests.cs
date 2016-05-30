using System;
using System.IO;
using FakeItEasy;
using NUnit.Framework;

namespace WordList.Data {
  [TestFixture]
  public class WordListFromFileDataSourceTests {
    IFileReader _fileReader;
    FileInfo _file;
    WordListFromFileDataSource _sut;

    [SetUp]
    public virtual void SetUp() {
      _fileReader = A.Fake<IFileReader>();
      _file = new FileInfo("TheWordList.fil");
      _sut = new WordListFromFileDataSource(_fileReader, _file);
    }

    [TestFixture]
    public class Construction : WordListFromFileDataSourceTests {
      [Test]
      public void GivenNullSourceFile_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListFromFileDataSource(_fileReader, null));
      }

      [Test]
      public void GivenNullFileReader_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListFromFileDataSource(null, _file));
      }
    }

    [TestFixture]
    public class LoadAll : WordListFromFileDataSourceTests {
      [Test]
      public void ReturnsWordDataRecord_ForEveryLineInSourceFile() {
        var fileLines = new[] {
          "FirstLine",
          "SecondLine",
          "ThirdLine"
        };
        A.CallTo(() => _fileReader.ReadAllLines(_file.FullName)).Returns(fileLines);

        var expected = new[] {
          new WordDataRecord { Value = "FirstLine" },
          new WordDataRecord { Value = "SecondLine" },
          new WordDataRecord { Value = "ThirdLine" }
        };

        var actual = _sut.LoadAll();

        Assert.That(actual, Is
          .EquivalentTo(expected)
          .Using(WordDataRecordComparison));
      }

      [Test]
      public void FiltersOutNullEmptyAndWhiteSpaceLines() {
        var fileLines = new[] {
          "FirstLine",
          "SecondLine",
          null,
          string.Empty,
          " ",
          "  " + Environment.NewLine,
          "ThirdLine"
        };
        A.CallTo(() => _fileReader.ReadAllLines(_file.FullName)).Returns(fileLines);

        var expected = new[] {
          new WordDataRecord { Value = "FirstLine" },
          new WordDataRecord { Value = "SecondLine" },
          new WordDataRecord { Value = "ThirdLine" }
        };

        var actual = _sut.LoadAll();

        Assert.That(actual, Is
          .EquivalentTo(expected)
          .Using(WordDataRecordComparison));
      }
    }

    static readonly Func<WordDataRecord, WordDataRecord, bool> WordDataRecordComparison = (actual, expected) => actual.Value == expected.Value;
  }
}