using System;
using System.Collections.Generic;
using System.Linq;

namespace WordList.Processing {
  public class WordsIndex : IWordsIndex {
    readonly ILookup<int, Word> _allWords;

    public WordsIndex(IEnumerable<Word> allWords) {
      if (allWords == null) throw new ArgumentNullException(nameof(allWords));
      _allWords = allWords.ToLookup(w => w.Length);
    }

    public IEnumerable<Word> GetWordsOfLength(int length) {
      if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));
      return _allWords[length];
    }
  }
}