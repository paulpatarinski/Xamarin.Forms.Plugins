using System.Collections.Generic;

namespace ExtendedListview.Forms.Plugin.WindowsPhone.ExtensionsMethods
{
  public static class IEnumerableExtensions
  {
    public static int IndexOf<T>(this IEnumerable<T> enumerable, T element, IEqualityComparer<T> comparer = null)
    {
      int i = 0;
      comparer = comparer ?? EqualityComparer<T>.Default;
      foreach (var currentElement in enumerable)
      {
        if (comparer.Equals(currentElement, element))
        {
          return i;
        }

        i++;
      }

      return -1;
    }

  }
}
