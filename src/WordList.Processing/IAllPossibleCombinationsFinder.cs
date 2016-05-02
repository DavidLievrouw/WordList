using System.Collections.Generic;

namespace WordList.Processing {
  public interface IAllPossibleCombinationsFinder {
    IEnumerable<WordCombination> FindAllPossibleCombinationsOfLength(IWordsIndex wordsIndex, int desiredLength);
  }
}