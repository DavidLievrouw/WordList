using System;
using System.Collections.Generic;
using System.Linq;

namespace WordList.Processing {
  public class WordsWithDesiredLengthFinder : IWordsWithDesiredLengthFinder {
    readonly int _desiredLength;

    public WordsWithDesiredLengthFinder(int desiredLength) {
      if (desiredLength < 1) throw new ArgumentOutOfRangeException(nameof(desiredLength));
      _desiredLength = desiredLength;
    }

    public IList<Word> FindWordsWithDesiredLength(IEnumerable<Word> allWords) {
      if (allWords == null) throw new ArgumentNullException(nameof(allWords));

      return allWords
        .Where(word => word.Length == _desiredLength)
        .ToList();
    }
  }
}