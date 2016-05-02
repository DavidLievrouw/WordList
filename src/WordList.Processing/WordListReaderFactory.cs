using System;
using WordList.Data;

namespace WordList.Processing {
  public class WordListReaderFactory : IWordListReaderFactory {
    readonly IFileReader _fileReader;

    public WordListReaderFactory(IFileReader fileReader) {
      if (fileReader == null) throw new ArgumentNullException(nameof(fileReader));
      _fileReader = fileReader;
    }

    public IWordListReader Create(ProgramSettings settings) {
      if (settings == null) throw new ArgumentNullException(nameof(settings));

      // Only the WordList from file is currently supported. Maybe insert Strategy pattern here?
      return new WordListReader(
        new WordListFromFileDataSource(
          _fileReader,
          settings.WordListFile));
    }
  }
}