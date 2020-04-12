using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class LeftBorderTask
    {
        // J: Хорошо сделано!
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (right - left <= 1) return left;
            var middle = left + (right - left) / 2;
            // J: Здесь можно выделить вспомогательный метод для условия терн. оператора 
            return (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) > 0) ?
                GetLeftBorderIndex(phrases, prefix, middle, right):
                GetLeftBorderIndex(phrases, prefix, left, middle);
        }
    }
}
