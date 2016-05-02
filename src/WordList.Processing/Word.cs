using System;

namespace WordList.Processing {
  public class Word {
    public Word(string value) {
      if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
      Value = value;
    }

    public string Value { get; }

    public override string ToString() {
      return Value;
    }

    protected bool Equals(Word other) {
      return string.Equals(Value, other.Value);
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      var other = obj as Word;
      return other != null && Equals(other);
    }

    public override int GetHashCode() {
      return Value.GetHashCode();
    }

    public static bool operator ==(Word left, Word right) {
      return Equals(left, right);
    }

    public static bool operator !=(Word left, Word right) {
      return !Equals(left, right);
    }
  }
}