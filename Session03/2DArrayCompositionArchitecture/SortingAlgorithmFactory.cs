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

    //This is an example of a basic factory pattern! This is a great pattern
    //that allows us to define an interface and multiple implementations.  We can then defer which class
    //is instantiated to the calling code at runtime
    //https://sourcemaking.com/design_patterns/factory_method
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
