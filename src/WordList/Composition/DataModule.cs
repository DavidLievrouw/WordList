using Autofac;
using WordList.Data;
using WordList.Processing;

namespace WordList.Composition {
  public class DataModule : Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);
      
      builder.RegisterType<FileReader>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder.RegisterType<WordListReaderFactory>()
        .AsImplementedInterfaces()
        .SingleInstance();
    }
  }
}