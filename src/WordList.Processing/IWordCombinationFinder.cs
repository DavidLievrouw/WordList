using System.Collections.Generic;

namespace WordList.Processing {
  public interface IWordCombinationFinder {
    IEnumerable<WordCombination> FindCombinations(IEnumerable<Word> words);
  }
}