using System;
using NUnit.Framework;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordTests {
    [TestFixture]
    public class Construction : WordTests {
      [Test]
      public void GivenNullValue_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Word(null));
      }

      [Test]
      public void GivenEmptyValue_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Word(string.Empty));
      }

      [Test]
      public void GivenWhiteSpaceValue_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Word("  " + Environment.NewLine));
      }

      [Test]
      public void GivenValidValue_SetsProperty() {
        var theValue = "The word value!";
        var actual = new Word(theValue);
        Assert.That(actual.Value, Is.EqualTo(theValue));
      }
    }

    [TestFixture]
    public class Equality : WordTests {
      [Test]
      public void IsNotEqualToNull() {
        var obj1 = new Word("MyValue");
        Word obj2 = null;

        Assert.That(!Equals(obj1, obj2));
        Assert.That(obj1 != obj2);
      }

      [Test]
      public void NullInstances_AreEqual() {
        Word obj1 = null;
        Word obj2 = null;

        Assert.That(Equals(obj1, obj2));
        Assert.That(obj1 == obj2);
      }

      [Test]
      public void ObjectsWithEqualValues_AreEqual() {
        var obj1 = new Word("MyValue");
        var obj2 = new Word("MyValue");

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1 == obj2);
        Assert.That(obj1.GetHashCode() == obj2.GetHashCode());
      }

      [Test]
      public void ObjectsWithDifferentCasedValues_AreNotEqual() {
        var obj1 = new Word("MyValue");
        var obj2 = new Word("Myvalue");

        Assert.That(!obj1.Equals(obj2));
        Assert.That(obj1 != obj2);
      }

      [Test]
      public void ObjectsWithDifferentValues_AreNotEqual() {
        var obj1 = new Word("MyValue1");
        var obj2 = new Word("MyValue2");

        Assert.That(!obj1.Equals(obj2));
        Assert.That(obj1 != obj2);
      }
    }
  }
}