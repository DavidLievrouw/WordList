using System.Collections.Generic;
using System.IO;

namespace WordList.Data {
  public class FileReader : IFileReader {
    public IEnumerable<string> ReadAllLines(string path) {
      if (!File.Exists(path)) throw new FileNotFoundException("The specified data source file could not be found.");
      return File.ReadAllLines(path);
    }
  }
}