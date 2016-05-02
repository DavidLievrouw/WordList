using System.Collections.Generic;

namespace WordList.Data {
  public interface IFileReader {
    IEnumerable<string> ReadAllLines(string path);
  }
}