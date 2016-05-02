using System.IO;
using WordList.Data;
using WordList.Processing;

namespace WordList {
  public class CompositionRoot {
    public CompositionRoot() {
      WordListReader = new WordListReader(
        new WordListFromFileDataSource(new FileReader(),
          new FileInfo("wordlist.txt")));

      WordCombinationFinder = new WordCombinationFinder(6);
    }

    public IWordListReader WordListReader { get; }

    public IWordCombinationFinder WordCombinationFinder { get; }
  }
}