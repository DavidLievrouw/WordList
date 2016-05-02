using System.Collections.Generic;

namespace WordList.Processing {
  public interface IWordsIndexFactory {
    IWordsIndex Create(IEnumerable<Word> allWords);
  }
}