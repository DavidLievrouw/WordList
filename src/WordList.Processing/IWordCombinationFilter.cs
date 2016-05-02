using System.Collections.Generic;

namespace WordList.Processing {
  public interface IWordCombinationFilter {
    IEnumerable<WordCombination> FilterByListOfPossibleWords(IEnumerable<WordCombination> combinations, IEnumerable<Word> wordsWithDesiredLength);
  }
}