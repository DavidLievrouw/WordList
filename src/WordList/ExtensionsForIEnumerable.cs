using System;
using System.Collections.Generic;

namespace WordList {
  public static class ExtensionsForIEnumerable {
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action) {
      if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
      foreach (var item in enumerable) {
        action?.Invoke(item);
      }
    }
  }
}