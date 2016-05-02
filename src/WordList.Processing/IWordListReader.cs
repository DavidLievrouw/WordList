using System.Collections.Generic;

namespace WordList.Processing {
  public interface IWordListReader {
    IEnumerable<Word> ReadWordList();
  }
}