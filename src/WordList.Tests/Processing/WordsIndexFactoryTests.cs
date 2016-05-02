using System;
using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordsIndexFactoryTests {
    WordsIndexFactory _sut;

    [SetUp]
    public void SetUp() {
      _sut = new WordsIndexFactory();
    }

    [TestFixture]
    public class Create : WordsIndexFactoryTests {
      [Test]
      public void GivenNullWords_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.Create(null));
      }

      [Test]
      public void CreatesWordsIndex() {
        var actual = _sut.Create(A.Dummy<IEnumerable<Word>>());
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.InstanceOf<IWordsIndex>());
      }
    }
  }
}