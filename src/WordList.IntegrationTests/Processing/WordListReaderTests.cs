using System.IO;
using System.Linq;
using NUnit.Framework;
using WordList.Data;

namespace WordList.Processing {
  [TestFixture]
  public class WordListReaderTests {
    FileInfo _sourceFile;
    FileReader _fileReader;
    IWordListDataSource _wordListDataSource;
    WordListReader _sut;

    [SetUp]
    public void SetUp() {
      _fileReader = new FileReader();
      _sourceFile = new FileInfo(Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "wordlist.txt"));
      _wordListDataSource = new WordListFromFileDataSource(_fileReader, _sourceFile);
      _sut = new WordListReader(_wordListDataSource);
    }

    [TestFixture]
    public class ReadWordList : WordListReaderTests {
      [Test]
      public void ReturnsWordForEveryLineInFile() {
        var expected = File
          .ReadAllLines(_sourceFile.FullName)
          .Select(line => new Word(line));
        var actual = _sut.ReadWordList();
        Assert.That(actual, Is.EquivalentTo(expected));
      }
    }
  }
}