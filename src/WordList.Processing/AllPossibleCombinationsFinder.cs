using System;
using System.Collections.Generic;
using System.Linq;

namespace WordList.Processing {
  public class AllPossibleCombinationsFinder : IAllPossibleCombinationsFinder {
    public IEnumerable<WordCombination> FindAllPossibleCombinationsOfLength(IWordsIndex wordsIndex, int desiredLength) {
      if (wordsIndex == null) throw new ArgumentNullException(nameof(wordsIndex));
      if (desiredLength < 1) throw new ArgumentOutOfRangeException(nameof(desiredLength));

      return Enumerable
        .Range(1, desiredLength - 1)
        .SelectMany(i => wordsIndex.GetWordsOfLength(i)
          .SelectMany(word => wordsIndex.GetWordsOfLength(desiredLength - i)
            .Select(otherWord => new WordCombination(word, otherWord))));
    }
  }
}