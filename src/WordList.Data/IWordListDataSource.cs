using System.Collections.Generic;

namespace WordList.Data {
  public interface IWordListDataSource {
    IEnumerable<WordDataRecord> LoadAll();
  }
}