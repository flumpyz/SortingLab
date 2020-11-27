using System;
using System.Collections.Generic;

namespace SortingLab.Interfaces
{
    public interface ISorter<T> where T : IComparable
    {
        T[] Sort(T[] sequence);
    }
}
