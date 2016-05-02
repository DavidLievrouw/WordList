using System;
using Autofac;
using WordList.Composition;

namespace WordList {
  public class Program {
    public static void Main(string[] args) {
      CompositionRoot.Compose().Resolve<IWordListProgram>().Run();
      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }
  }
}