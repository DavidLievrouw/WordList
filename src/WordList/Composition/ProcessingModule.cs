using Autofac;
using WordList.Processing;

namespace WordList.Composition {
  public class ProcessingModule : Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder.RegisterType<WordListReader>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder.RegisterType<WordsIndexFactory>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder.RegisterType<AllPossibleCombinationsFinder>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder.RegisterType<WordCombinationFilter>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder.RegisterType<WordCombinationFinderFactory>()
        .AsImplementedInterfaces()
        .SingleInstance();
    }
  }
}