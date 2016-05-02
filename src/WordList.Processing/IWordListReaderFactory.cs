namespace WordList.Processing {
  public interface IWordListReaderFactory {
    IWordListReader Create(ProgramSettings settings);
  }
}
