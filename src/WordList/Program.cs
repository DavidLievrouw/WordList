using System;
using Autofac;
using WordList.Composition;

namespace WordList {
  public class Program {
    public static void Main(string[] args) {
      var compositionRoot = CompositionRoot.Compose();
      var wordListProgram = compositionRoot.Resolve<IWordListProgram>();
      wordListProgram.Run();

      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }
  }
}