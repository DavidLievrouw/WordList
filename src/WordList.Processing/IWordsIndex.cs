using System.Collections.Generic;

namespace WordList.Processing {
  public interface IWordsIndex {
    IEnumerable<Word> GetWordsOfLength(int length);
  }
}