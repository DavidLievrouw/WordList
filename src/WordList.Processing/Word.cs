using System;
using WordList.Data;

namespace WordList.Processing {
  public class Word : IWord {
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