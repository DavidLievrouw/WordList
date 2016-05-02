using Autofac;
using WordList.Data;

namespace WordList.Composition {
  public class DataModule : Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);
      
      builder.RegisterType<FileReader>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder.Register(ctx => new WordListFromFileDataSource(
        ctx.Resolve<IFileReader>(),
        ctx.Resolve<ProgramSettings>().WordListFile))
        .AsImplementedInterfaces()
        .SingleInstance();
    }
  }
}