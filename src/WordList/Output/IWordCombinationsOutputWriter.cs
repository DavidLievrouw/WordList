using System.Collections.Generic;
using WordList.Processing;

namespace WordList.Output {
  public interface IWordCombinationsOutputWriter {
    void Write(IEnumerable<WordCombination> wordCombinations);
  }
}