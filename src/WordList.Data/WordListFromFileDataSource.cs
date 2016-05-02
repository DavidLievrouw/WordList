using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordList.Data {
  public class WordListFromFileDataSource : IWordListDataSource {
    readonly IFileReader _fileReader;
    readonly FileInfo _file;

    public WordListFromFileDataSource(IFileReader fileReader, FileInfo file) {
      if (fileReader == null) throw new ArgumentNullException(nameof(fileReader));
      if (file == null) throw new ArgumentNullException(nameof(file));
      _fileReader = fileReader;
      _file = file;
    }

    public IEnumerable<WordDataRecord> LoadAll() {
      return _fileReader
        .ReadAllLines(_file.FullName)
        .Select(line => new WordDataRecord { Value = line });
    }
  }
}