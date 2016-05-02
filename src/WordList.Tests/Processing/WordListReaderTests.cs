using System;
using FakeItEasy;
using NUnit.Framework;
using WordList.Data;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordListReaderTests {
    IWordListDataSource _wordListDataSource;
    WordListReader _sut;

    [SetUp]
    public void SetUp() {
      _wordListDataSource = A.Fake<IWordListDataSource>();
      _sut = new WordListReader(_wordListDataSource);
    }

    [TestFixture]
    public class Construction : WordListReaderTests {
      [Test]
      public void GivenNullWordListDataSource_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordListReader(null));
      }
    }

    [TestFixture]
    public class ReadWordList : WordListReaderTests {
      [Test]
      public void ReturnsWordForEveryDataRecord() {
        var dataRecords = new[] {
          new WordDataRecord { Value = "FirstLine" },
          new WordDataRecord { Value = "SecondLine" },
          new WordDataRecord { Value = "ThirdLine" }
        };
        A.CallTo(() => _wordListDataSource.LoadAll()).Returns(dataRecords);

        var expected = new[] {
          new Word("FirstLine"),
          new Word("SecondLine"),
          new Word("ThirdLine")
        };

        var actual = _sut.ReadWordList();

        Assert.That(actual, Is.EquivalentTo(expected));
      }
    }
  }
}