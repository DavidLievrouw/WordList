using System;
using System.Collections.Generic;
using System.Linq;

namespace WordList.Processing {
  public class WordCombinationFinder : IWordCombinationFinder {
    readonly int _desiredLength;
    readonly IWordsIndexFactory _wordsIndexFactory;
    readonly IAllPossibleCombinationsFinder _allPossibleCombinationsFinder;
    readonly IWordCombinationFilter _wordCombinationFilter;

    public WordCombinationFinder(
      int desiredLength,
      IWordsIndexFactory wordsIndexFactory,
      IAllPossibleCombinationsFinder allPossibleCombinationsFinder,
      IWordCombinationFilter wordCombinationFilter) {
      if (wordsIndexFactory == null) throw new ArgumentNullException(nameof(wordsIndexFactory));
      if (allPossibleCombinationsFinder == null) throw new ArgumentNullException(nameof(allPossibleCombinationsFinder));
      if (wordCombinationFilter == null) throw new ArgumentNullException(nameof(wordCombinationFilter));
      if (desiredLength < 1) throw new ArgumentOutOfRangeException(nameof(desiredLength));
      _desiredLength = desiredLength;
      _wordsIndexFactory = wordsIndexFactory;
      _allPossibleCombinationsFinder = allPossibleCombinationsFinder;
      _wordCombinationFilter = wordCombinationFilter;
    }

    public IEnumerable<WordCombination> FindCombinations(IEnumerable<Word> words) {
      if (words == null) throw new ArgumentNullException(nameof(words));

      var wordsIndex = _wordsIndexFactory.Create(words);
      var wordsWithDesiredLength = wordsIndex.GetWordsOfLength(_desiredLength);

      var allPossibleCombinationsWithDesiredLength = _allPossibleCombinationsFinder.FindAllPossibleCombinationsOfLength(wordsIndex, _desiredLength);
      var combinationsThatAppearInTheList = _wordCombinationFilter.FilterByListOfPossibleWords(allPossibleCombinationsWithDesiredLength, wordsWithDesiredLength);

      return combinationsThatAppearInTheList.Distinct();
    }
  }
}