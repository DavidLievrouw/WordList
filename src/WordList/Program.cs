using System;

namespace WordList {
  public class Program {
    static void Main(string[] args) {
      var compositionRoot = new CompositionRoot();

      var words = compositionRoot.WordListReader.ReadWordList();
      var combinations = compositionRoot.WordCombinationFinder.FindCombinations(words);

      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }

  }
}