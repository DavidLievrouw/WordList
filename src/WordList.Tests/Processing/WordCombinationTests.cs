using System;
using NUnit.Framework;
using WordList.Processing;

namespace WordList.Tests.Processing {
  [TestFixture]
  public class WordCombinationTests {
    Word _word1;
    Word _word2;
    Word _word3;

    [SetUp]
    public void SetUp() {
      _word1 = new Word("TheFirstWord");
      _word2 = new Word("TheSecondWord");
      _word3 = new Word("TheThirdWord");
    }

    [TestFixture]
    public class Construction : WordCombinationTests {
      [Test]
      public void GivenNullWords_Throws() {
        Assert.Throws<ArgumentNullException>(() => new WordCombination(_word1, null));
        Assert.Throws<ArgumentNullException>(() => new WordCombination(null, _word2));
      }
    }

    [TestFixture]
    public class Equality : WordCombinationTests {
      [Test]
      public void IsNotEqualToNull() {
        var obj1 = new WordCombination(_word1, _word2);
        WordCombination obj2 = null;

        Assert.That(!Equals(obj1, obj2));
        Assert.That(obj1 != obj2);
      }

      [Test]
      public void NullInstances_AreEqual() {
        WordCombination obj1 = null;
        WordCombination obj2 = null;

        Assert.That(Equals(obj1, obj2));
        Assert.That(obj1 == obj2);
      }

      [Test]
      public void ObjectsWithEqualWords_AreEqual() {
        var obj1 = new WordCombination(_word1, _word2);
        var obj2 = new WordCombination(_word1, _word2);

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1 == obj2);
        Assert.That(obj1.GetHashCode() == obj2.GetHashCode());
      }

      [Test]
      public void ObjectsWithWordsInReversedOrder_AreNotEqual() {
        var obj1 = new WordCombination(_word1, _word2);
        var obj2 = new WordCombination(_word2, _word1);

        Assert.That(!obj1.Equals(obj2));
        Assert.That(obj1 != obj2);
      }

      [Test]
      public void ObjectsWithDifferentWords_AreNotEqual() {
        var obj1 = new WordCombination(_word1, _word2);
        var obj2 = new WordCombination(_word1, _word3);

        Assert.That(!obj1.Equals(obj2));
        Assert.That(obj1 != obj2);
      }

      [Test]
      public void SubTypeWithEqualWords_AreEqual() {
        var obj1 = new WordCombination(_word1, _word2);
        var obj2 = new SubTypeOfWordCombination(_word1, _word2);

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1 == obj2);
        Assert.That(obj1.GetHashCode() == obj2.GetHashCode());
      }

      class SubTypeOfWordCombination : WordCombination {
        public SubTypeOfWordCombination(Word word1, Word word2) : base(word1, word2) {}
      }
    }
  }
}