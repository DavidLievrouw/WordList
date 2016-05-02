using System;
using System.Collections.Generic;
using System.Linq;
using WordList.Data;

namespace WordList.Processing {
  public class WordListReader : IWordListReader {
    readonly IWordListDataSource _wordListDataSource;

    public WordListReader(IWordListDataSource wordListDataSource) {
      if (wordListDataSource == null) throw new ArgumentNullException(nameof(wordListDataSource));
      _wordListDataSource = wordListDataSource;
    }

    public IEnumerable<Word> ReadWordList() {
      return _wordListDataSource
        .LoadAll()
        .Select(dataRecord => new Word(dataRecord));
    }
  }
}