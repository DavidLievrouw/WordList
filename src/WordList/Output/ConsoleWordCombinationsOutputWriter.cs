using System;
using System.Collections.Generic;
using System.Linq;
using WordList.Processing;

namespace WordList.Output {
  public class ConsoleWordCombinationsOutputWriter : IWordCombinationsOutputWriter {
    readonly IConsole _console;

    public ConsoleWordCombinationsOutputWriter(IConsole console) {
      if (console == null) throw new ArgumentNullException(nameof(console));
      _console = console;
    }

    public void Write(IEnumerable<WordCombination> wordCombinations) {
      if (wordCombinations == null) throw new ArgumentNullException(nameof(wordCombinations));

      var materializedCombinations = wordCombinations.ToList();

      if (!materializedCombinations.Any()) _console.WriteLine("No combinations found");
      materializedCombinations.ForEach(combination => _console.WriteLine(combination.ToString()));
    }
  }
}