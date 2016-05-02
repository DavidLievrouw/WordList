namespace WordList.Processing {
  public interface IWordCombinationFinderFactory {
    IWordCombinationFinder Create(ProgramSettings settings);
  }
}