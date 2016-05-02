using System;

namespace WordList.Processing {
  public class WordCombination : IWord, IEquatable<IWord> {
    readonly Word _word1;
    readonly Word _word2;

    public WordCombination(Word word1, Word word2) {
      if (word1 == null) throw new ArgumentNullException(nameof(word1));
      if (word2 == null) throw new ArgumentNullException(nameof(word2));
      _word1 = word1;
      _word2 = word2;
    }

    public bool Equals(IWord other) {
      if (ReferenceEquals(null, other)) return false;
      return ReferenceEquals(this, other) || string.Equals(Value, other.Value);
    }

    public override string ToString() {
      return $"{_word1.Value} + {_word2.Value} => {_word1.Value + _word2.Value}";
    }

    public override bool Equals(object obj) {
      return Equals(obj as IWord);
    }

    public override int GetHashCode() {
      return Value.GetHashCode();
    }

    public static bool operator ==(WordCombination left, IWord right) {
      if (ReferenceEquals(null, left) && ReferenceEquals(null, right)) return true;
      return !ReferenceEquals(null, left) && left.Equals(right);
    }

    public static bool operator !=(WordCombination left, IWord right) {
      if (ReferenceEquals(null, left) && ReferenceEquals(null, right)) return false;
      if (ReferenceEquals(null, left)) return true;
      return !left.Equals(right);
    }

    public string Value => _word1.ToString() + _word2.ToString();
    public int Length => _word1.Length + _word2.Length;
  }
}