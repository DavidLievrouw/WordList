using System;
using WordList.Output;
using WordList.Processing;

namespace WordList {
  public class WordListProgram : IWordListProgram {
    readonly IWordListReaderFactory _wordListReaderFactory;
    readonly IWordCombinationFinderFactory _wordCombinationFinderFactory;
    readonly IWordCombinationsOutputWriter _outputWriter;
    readonly ProgramSettings _settings;

    public WordListProgram(
      IWordListReaderFactory wordListReaderFactory,
      IWordCombinationFinderFactory wordCombinationFinderFactory,
      IWordCombinationsOutputWriter outputWriter,
      ProgramSettings settings) {
      if (wordListReaderFactory == null) throw new ArgumentNullException(nameof(wordListReaderFactory));
      if (wordCombinationFinderFactory == null) throw new ArgumentNullException(nameof(wordCombinationFinderFactory));
      if (outputWriter == null) throw new ArgumentNullException(nameof(outputWriter));
      if (settings == null) throw new ArgumentNullException(nameof(settings));
      _wordListReaderFactory = wordListReaderFactory;
      _wordCombinationFinderFactory = wordCombinationFinderFactory;
      _outputWriter = outputWriter;
      _settings = settings;
    }

    public void Run() {
      var words = _wordListReaderFactory.Create(_settings).ReadWordList();
      var combinations = _wordCombinationFinderFactory.Create(_settings).FindCombinations(words);
      _outputWriter.Write(combinations);
    }
  }
}