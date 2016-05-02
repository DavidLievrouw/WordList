using System;
using Autofac;
using WordList.Composition;
using WordList.Output;
using WordList.Processing;

namespace WordList {
  public class Program {
    public static void Main(string[] args) {
      var compositionRoot = CompositionRoot.Compose();

      var wordListReader = compositionRoot.Resolve<IWordListReader>();
      var wordCombinationFinder = compositionRoot.Resolve<IWordCombinationFinder>();
      var wordCombinationOutputWriter = compositionRoot.Resolve<IWordCombinationOutputWriter>();

      var words = wordListReader.ReadWordList();
      var combinations = wordCombinationFinder.FindCombinations(words);
      wordCombinationOutputWriter.OutputWordCombinations(combinations);

      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }
  }
}