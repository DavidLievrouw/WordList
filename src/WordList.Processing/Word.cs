using System;
using WordList.Data;

namespace WordList.Processing {
  public class Word : IWord, IEquatable<IWord> {
    public Word(string value) {
      if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
      Value = value;
    }

    public Word(WordDataRecord dataRecord) {
      if (dataRecord == null) throw new ArgumentNullException(nameof(dataRecord));
      if (string.IsNullOrWhiteSpace(dataRecord.Value)) throw new ArgumentException($"The specified {dataRecord.GetType().Name} does not have a valid value.", nameof(dataRecord));
      Value = dataRecord.Value;
    }

    public string Value { get; }

    public int Length => Value.Length;

    public bool Equals(IWord other) {
      if (ReferenceEquals(null, other)) return false;
      return ReferenceEquals(this, other) || string.Equals(Value, other.Value);
    }

    public override string ToString() {
      return Value;
    }

    public override bool Equals(object obj) {
      return Equals(obj as IWord);
    }

    public override int GetHashCode() {
      return Value.GetHashCode();
    }

    public static bool operator ==(Word left, IWord right) {
      if (ReferenceEquals(null, left) && ReferenceEquals(null, right)) return true;
      return !ReferenceEquals(null, left) && left.Equals(right);
    }

    public static bool operator !=(Word left, IWord right) {
      if (ReferenceEquals(null, left) && ReferenceEquals(null, right)) return false;
      if (ReferenceEquals(null, left)) return true;
      return !left.Equals(right);
    }
  }
}