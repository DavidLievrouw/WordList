using System;

namespace WordList.Processing {
  public class WordCombination : IWord {
    readonly Word _word1;
    readonly Word _word2;

    public WordCombination(Word word1, Word word2) {
      if (word1 == null) throw new ArgumentNullException(nameof(word1));
      if (word2 == null) throw new ArgumentNullException(nameof(word2));
      _word1 = word1;
      _word2 = word2;
    }

    public string Value => _word1.ToString() + _word2.ToString();
    public int Length => _word1.Length + _word2.Length;

    public override string ToString() {
      return $"{_word1.Value} + {_word2.Value} => {_word1.Value + _word2.Value}";
    }

    protected bool Equals(WordCombination other) {
      return _word1.Equals(other._word1) && _word2.Equals(other._word2);
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      var other = obj as WordCombination;
      return other != null && Equals(other);
    }

    public override int GetHashCode() {
      unchecked {
        return (_word1.GetHashCode()*397) ^ _word2.GetHashCode();
      }
    }

    public static bool operator ==(WordCombination left, WordCombination right) {
      return Equals(left, right);
    }

    public static bool operator !=(WordCombination left, WordCombination right) {
      return !Equals(left, right);
    }
  }
}