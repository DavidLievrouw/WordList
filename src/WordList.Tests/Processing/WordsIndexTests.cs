using System;
using System.Linq;
using NUnit.Framework;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordsIndexTests {
    WordsIndex _sut;
    Word[] _allWords;
    int _desiredLength;
    Word[] _expected;

    [SetUp]
    public virtual void SetUp() {
      _allWords = new[] {
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
      _desiredLength = 6;
      _expected = _allWords.Where(w => w.Length == _desiredLength).ToArray();
      _sut = new WordsIndex(_allWords);
    }

    [TestFixture]
    public class Construction : WordsIndexTests {
      [Test]
      public void GivenNullWords_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordsIndex(null));
      }
    }

    [TestFixture]
    public class GetWordsOfLength : WordsIndexTests {
      [TestCase(0)]
      [TestCase(-1)]
      [TestCase(int.MinValue)]
      public void GivenInvalidDesiredLength_Throws(int invalidDesiredLength) {
        Assert.Throws<ArgumentOutOfRangeException>(() => _sut.GetWordsOfLength(invalidDesiredLength));
      }

      [Test]
      public void GetsWordsOfSpecifiedLength() {
        var actual = _sut.GetWordsOfLength(6);
        Assert.That(actual, Is.EquivalentTo(_expected));
      }
    }
  }
}