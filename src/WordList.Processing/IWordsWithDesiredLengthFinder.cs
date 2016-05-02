using System.Collections.Generic;

namespace WordList.Processing {
  public interface IWordsWithDesiredLengthFinder {
    IList<Word> FindWordsWithDesiredLength(IEnumerable<Word> allWords);
  }
}