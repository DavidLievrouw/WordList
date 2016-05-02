using System.Configuration;
using System.IO;
using Autofac;

namespace WordList.Composition {
  public static class CompositionRoot {
    public static IContainer Compose() {
      var defaultConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      return Compose(defaultConfig);
    }

    public static IContainer Compose(Configuration configuration) {
      var builder = new ContainerBuilder();

      builder.Register(ctx => int.Parse(configuration.AppSettings.Settings["DesiredWordLength"].Value))
        .Named<int>("AppSetting_DesiredWordLength")
        .SingleInstance();
      builder.Register(ctx => new FileInfo(configuration.AppSettings.Settings["WordListFile"].Value))
        .Named<FileInfo>("AppSetting_WordListFile")
        .SingleInstance();
      
      builder.RegisterModule<DataModule>();
      builder.RegisterModule<UIModule>();
      builder.RegisterModule<ProcessingModule>();

      return builder.Build();
    }
  }
}