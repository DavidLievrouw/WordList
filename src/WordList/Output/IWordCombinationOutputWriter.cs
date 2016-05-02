using System.Collections.Generic;
using WordList.Processing;

namespace WordList.Output {
  public interface IWordCombinationOutputWriter {
    void OutputWordCombinations(IEnumerable<WordCombination> wordCombinations);
  }
}