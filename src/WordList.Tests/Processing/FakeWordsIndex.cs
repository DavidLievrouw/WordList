using System;
using System.Collections.Generic;
using System.Linq;
using WordList.Processing;

namespace WordList.Tests.Processing {
  public class FakeWordsIndex : IWordsIndex {
    readonly IEnumerable<Word> _allWords;

    public FakeWordsIndex(IEnumerable<Word> allWords) {
      if (allWords == null) throw new ArgumentNullException(nameof(allWords));
      _allWords = allWords;
    }

    public IEnumerable<Word> GetWordsOfLength(int length) {
      return _allWords.ToLookup(w => w.Length)[length];
    }
  }
}