using System;

namespace WordList.Processing {
  public class WordCombinationFinderFactory : IWordCombinationFinderFactory {
    readonly IWordsIndexFactory _wordsIndexFactory;
    readonly IAllPossibleCombinationsFinder _allPossibleCombinationsFinder;
    readonly IWordCombinationFilter _wordCombinationFilter;

    public WordCombinationFinderFactory(
      IWordsIndexFactory wordsIndexFactory,
      IAllPossibleCombinationsFinder allPossibleCombinationsFinder,
      IWordCombinationFilter wordCombinationFilter) {
      if (wordsIndexFactory == null) throw new ArgumentNullException(nameof(wordsIndexFactory));
      if (allPossibleCombinationsFinder == null) throw new ArgumentNullException(nameof(allPossibleCombinationsFinder));
      if (wordCombinationFilter == null) throw new ArgumentNullException(nameof(wordCombinationFilter));
      _wordsIndexFactory = wordsIndexFactory;
      _allPossibleCombinationsFinder = allPossibleCombinationsFinder;
      _wordCombinationFilter = wordCombinationFilter;
    }

    public IWordCombinationFinder Create(ProgramSettings settings) {
      if (settings == null) throw new ArgumentNullException(nameof(settings));
      if (settings.DesiredWordLength < 1) throw new ArgumentOutOfRangeException(nameof(settings), "The specified desired word length is invalid.");
      return new WordCombinationFinder(settings.DesiredWordLength, _wordsIndexFactory, _allPossibleCombinationsFinder, _wordCombinationFilter);
    }
  }
}