using System;
using Autofac;
using NUnit.Framework;
using WordList.Composition;
using WordList.Output;
using WordList.Processing;

namespace WordList.Tests.Composition {
  [TestFixture]
  public class CompositionRootTests {
    IContainer _container;

    [OneTimeSetUp]
    public void OneTimeSetup() {
      _container = CompositionRoot.Compose();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() {
      _container.Dispose();
    }
    
    [TestCase(typeof(IWordListReader))]
    [TestCase(typeof(IWordCombinationFinder))]
    [TestCase(typeof(IWordCombinationOutputWriter))]
    public void RegistersStuffCorrectly(Type typeToCheck) {
      object actualResult = null;
      Assert.DoesNotThrow(() => actualResult = _container.Resolve(typeToCheck));
      Assert.That(actualResult, Is.Not.Null);
      Assert.That(actualResult, Is.AssignableTo(typeToCheck));
    }

    [TestCase(typeof(IWordListReader))]
    [TestCase(typeof(IWordCombinationFinder))]
    [TestCase(typeof(IWordCombinationOutputWriter))]
    public void RegistersStuffAsSingleton(Type typeToCheck) {
      var actualResult1 = _container.Resolve(typeToCheck);
      var actualResult2 = _container.Resolve(typeToCheck);
      Assert.That(actualResult1, Is.SameAs(actualResult2));
    }
  }
}