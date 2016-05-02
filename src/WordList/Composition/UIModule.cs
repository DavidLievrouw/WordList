using Autofac;
using WordList.Output;

namespace WordList.Composition {
  public class UIModule : Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder.RegisterType<RealConsole>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder.RegisterType<ConsoleWordCombinationsOutputWriter>()
        .AsImplementedInterfaces()
        .SingleInstance();
    }
  }
}