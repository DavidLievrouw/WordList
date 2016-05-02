using System;

namespace WordList {
  public class Program {
    public static void Main(string[] args) {
      var compositionRoot = new CompositionRoot();

      var words = compositionRoot.WordListReader.ReadWordList();
      var combinations = compositionRoot.WordCombinationFinder.FindCombinations(words);
      compositionRoot.WordCombinationOutputWriter.OutputWordCombinations(combinations);

      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }

  }
}