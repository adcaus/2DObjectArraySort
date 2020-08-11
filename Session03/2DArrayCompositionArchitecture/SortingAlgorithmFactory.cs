using System;
using System.Collections.Generic;
using System.Text;
using _2DArrayCompositionArchitecture.SortingStrategies;

namespace _2DArrayCompositionArchitecture
{
    public enum SortingAlgorithm
    {
        Quick,
        Selection
    }

    public static class SortingAlgorithmFactory
    {
        public static ISortingStrategy<T> CreateSorter<T>(T[,] array, SortingAlgorithm sortingAlgorithm = SortingAlgorithm.Quick)
            where T : IComparable<T>, IComparableWithProperties
        {
            return sortingAlgorithm switch
            {
                SortingAlgorithm.Quick => new QuickSortStrategy<T>(array),
                SortingAlgorithm.Selection => new SelectionSortStrategy<T>(array),
                _ => throw new ArgumentOutOfRangeException(nameof(sortingAlgorithm), sortingAlgorithm, null)
            };
        }
    }
}
