using Autofac;
using WordList.Processing;

namespace WordList.Composition {
  public class ProcessingModule : Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);
      
      builder.RegisterType<WordListReader>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder.Register(ctx => new WordCombinationFinder(ctx.ResolveNamed<int>("AppSetting_DesiredWordLength")))
        .AsImplementedInterfaces()
        .SingleInstance();
    }
  }
}