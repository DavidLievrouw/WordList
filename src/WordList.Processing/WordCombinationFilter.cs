using System;
using System.Collections.Generic;
using System.Linq;

namespace WordList.Processing {
  public class WordCombinationFilter : IWordCombinationFilter {
    public IEnumerable<WordCombination> FilterByListOfPossibleWords(IEnumerable<WordCombination> combinations, IEnumerable<Word> wordsWithDesiredLength) {
      if (combinations == null) throw new ArgumentNullException(nameof(combinations));
      if (wordsWithDesiredLength == null) throw new ArgumentNullException(nameof(wordsWithDesiredLength));

      // HashSet with WordEqualityComparer as performance optimization
      var wordEqualityComparer = new WordEqualityComparer();
      var wordsWithDesiredLengthSet = new HashSet<Word>(wordsWithDesiredLength, wordEqualityComparer);
      return combinations
        .Where(combination => wordsWithDesiredLengthSet.Contains(combination));
    }

    class WordEqualityComparer : IEqualityComparer<Word> {
      public bool Equals(Word x, Word y) {
        if (x == null && y == null) return true;
        return x != null && x.Equals(y);
      }

      public int GetHashCode(Word word) {
        return word.GetHashCode();
      }
    }
  }
}