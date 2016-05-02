using System;
using System.Collections.Generic;
using System.Linq;

namespace WordList.Processing {
  public class WordCombinationFinder : IWordCombinationFinder {
    readonly int _desiredLength;

    public WordCombinationFinder(int desiredLength) {
      if (desiredLength < 1) throw new ArgumentOutOfRangeException(nameof(desiredLength));
      _desiredLength = desiredLength;
    }

    public IEnumerable<WordCombination> FindCombinations(IEnumerable<Word> words) {
      if (words == null) throw new ArgumentNullException(nameof(words));

      var wordsByLength = words.ToLookup(w => w.Length);
      var wordsWithDesiredLength = wordsByLength[_desiredLength].ToList();
      if (!wordsWithDesiredLength.Any()) return Enumerable.Empty<WordCombination>();

      var allPossibleCombinationsWithDesiredLength = Enumerable
        .Range(1, _desiredLength - 1)
        .SelectMany(i => wordsByLength[i]
          .SelectMany(word => wordsByLength[_desiredLength - i]
            .Select(otherWord => new WordCombination(word, otherWord))));

      // HashSet with WordEqualityComparer as performance optimization
      var wordEqualityComparer = new WordEqualityComparer();
      var wordsWithDesiredLengthSet = new HashSet<Word>(wordsWithDesiredLength, wordEqualityComparer);
      var combinationsThatAppearInTheList = allPossibleCombinationsWithDesiredLength
        .Where(combination => wordsWithDesiredLengthSet.Contains(new Word(combination.Value)));

      return combinationsThatAppearInTheList.Distinct();
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