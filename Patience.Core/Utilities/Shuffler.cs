using Patience.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patience.Core.Utilities;

public static class Shuffler<T>
{
    private static Random r = new Random();

    public static List<T> Shuffle(List<T> items)
    {
        for (int i = 0; i < items.Count - 1; i++)
        {
            int pos = r.Next(i, items.Count);
            T temp = items[i];
            items[i] = items[pos];
            items[pos] = temp;
        }
        return items;
    }
}
