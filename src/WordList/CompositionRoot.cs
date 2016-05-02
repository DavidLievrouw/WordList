using System.IO;
using WordList.Data;
using WordList.Output;
using WordList.Processing;

namespace WordList {
  public class CompositionRoot {
    public CompositionRoot() {
      WordListReader = new WordListReader(
        new WordListFromFileDataSource(new FileReader(),
          new FileInfo("wordlist.txt")));

      WordCombinationFinder = new WordCombinationFinder(6);

      WordCombinationOutputWriter = new WordCombinationOutputWriter(new RealConsole());
    }

    public IWordListReader WordListReader { get; }

    public IWordCombinationFinder WordCombinationFinder { get; }

    public IWordCombinationOutputWriter WordCombinationOutputWriter { get; }
  }
}