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

      var combinationsThatAppearInTheList = allPossibleCombinationsWithDesiredLength
        .Where(combination => wordsWithDesiredLength.Contains((IWord)combination));

      return combinationsThatAppearInTheList.Distinct();
    }
  }
}