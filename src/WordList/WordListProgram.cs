using System;
using WordList.Output;
using WordList.Processing;

namespace WordList {
  public class WordListProgram : IWordListProgram {
    readonly IWordListReader _wordListReader;
    readonly IWordCombinationFinder _wordCombinationFinder;
    readonly IWordCombinationsOutputWriter _outputWriter;

    public WordListProgram(IWordListReader wordListReader, IWordCombinationFinder wordCombinationFinder, IWordCombinationsOutputWriter outputWriter) {
      if (wordListReader == null) throw new ArgumentNullException(nameof(wordListReader));
      if (wordCombinationFinder == null) throw new ArgumentNullException(nameof(wordCombinationFinder));
      if (outputWriter == null) throw new ArgumentNullException(nameof(outputWriter));
      _wordListReader = wordListReader;
      _wordCombinationFinder = wordCombinationFinder;
      _outputWriter = outputWriter;
    }

    public void Run() {
      var words = _wordListReader.ReadWordList();
      var combinations = _wordCombinationFinder.FindCombinations(words);
      _outputWriter.Write(combinations);
    }
  }
}