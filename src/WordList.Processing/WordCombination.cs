using System;

namespace WordList.Processing {
  public class WordCombination {
    readonly Word _left;
    readonly Word _right;

    public WordCombination(Word left, Word right) {
      if (left == null) throw new ArgumentNullException(nameof(left));
      if (right == null) throw new ArgumentNullException(nameof(right));
      _left = left;
      _right = right;
    }

    public string Value => _left.ToString() + _right.ToString();

    public override string ToString() {
      return $"{_left.Value} + {_right.Value} => {_left.Value + _right.Value}";
    }

    protected bool Equals(WordCombination other) {
      return _left.Equals(other._left) && _right.Equals(other._right);
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      var other = obj as WordCombination;
      return other != null && Equals(other);
    }

    public override int GetHashCode() {
      unchecked {
        return (_left.GetHashCode()*397) ^ _right.GetHashCode();
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