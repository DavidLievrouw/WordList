using System;

namespace WordList.Output {
  public class RealConsole : IConsole {
    public void WriteLine(string value) {
      Console.WriteLine(value);
    }
  }
}