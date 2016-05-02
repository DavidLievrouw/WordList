using System;
using NUnit.Framework;
using WordList.Data;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordTests {
    [TestFixture]
    public class ConstructionByValue : WordTests {
      [Test]
      public void GivenNullValue_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Word((string)null));
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
        var sut = new Word(theValue);
        var actual = sut.Value;
        Assert.That(actual, Is.EqualTo(theValue));
      }
    }

    [TestFixture]
    public class ConstructionByDataRecord : WordTests {
      [Test]
      public void GivenNullDataRecord_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Word((WordDataRecord)null));
      }

      [Test]
      public void GivenNullDataRecordValue_Throws() {
        Assert.Throws<ArgumentException>(() => new Word(new WordDataRecord { Value = null }));
      }

      [Test]
      public void GivenEmptyDataRecordValue_Throws() {
        Assert.Throws<ArgumentException>(() => new Word(new WordDataRecord { Value = string.Empty }));
      }

      [Test]
      public void GivenWhiteSpaceDataRecordValue_Throws() {
        Assert.Throws<ArgumentException>(() => new Word(new WordDataRecord { Value = "  " + Environment.NewLine }));
      }

      [Test]
      public void GivenValidDataRecordValue_SetsProperty() {
        var theValue = "The word value!";
        var dataRecord = new WordDataRecord { Value = theValue };
        var sut = new Word(dataRecord);
        var actual = sut.Value;
        Assert.That(actual, Is.EqualTo(theValue));
      }
    }

    [TestFixture]
    public new class ToString : WordTests {
      [Test]
      public void ToString_ReturnsValue() {
        var theValue = "The word value!";
        var sut = new Word(theValue);
        var actual = sut.ToString();
        Assert.That(actual, Is.EqualTo(theValue));
      }
    }

    [TestFixture]
    public class Length : WordTests {
      [TestCase("12345", 5)]
      [TestCase("12345 789", 9)]
      [TestCase("1", 1)]
      [TestCase(" 123 ", 5)]
      public void Length_ReturnsLengthOfValue(string value, int expectedLength) {
        var sut = new Word(value);
        var actual = sut.Length;
        Assert.That(actual, Is.EqualTo(expectedLength));
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

      [Test]
      public void SubTypeWithEqualWords_AreEqual() {
        var obj1 = new Word("MyValue1");
        var obj2 = new SubTypeOfWord("MyValue1");

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1 == obj2);
        Assert.That(obj1.GetHashCode() == obj2.GetHashCode());
      }

      [Test]
      public void IWordEqualValue_AreEqual() {
        var obj1 = new WordCombination(new Word("AA"), new Word("BB"));
        IWord obj2 = new Word("AABB");

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1 == obj2);
        Assert.That(obj1.GetHashCode() == obj2.GetHashCode());
      }

      class SubTypeOfWord : Word {
        public SubTypeOfWord(string value) : base(value) {}
      }
    }
  }
}