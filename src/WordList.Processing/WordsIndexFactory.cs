using System;
using System.Collections.Generic;

namespace WordList.Processing {
  public class WordsIndexFactory : IWordsIndexFactory {
    public IWordsIndex Create(IEnumerable<Word> allWords) {
      if (allWords == null) throw new ArgumentNullException(nameof(allWords));
      return new WordsIndex(allWords);
    }
  }
}