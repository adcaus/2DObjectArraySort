using System.Collections.Generic;

namespace _2DArrayCompositionArchitecture.SortingStrategies
{
    //This interface provides a hook for various Sorting Strategies to implement.  This is a simple pattern where
    //Each implementation is interchangeable and provides a modular plugin where the class instance can be inserted
    //https://sourcemaking.com/design_patterns/strategy

    /// <summary>
    /// Defines an abstraction for different sorting algorithms to implement
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISortingStrategy<T>
    {
        public void SortBySelectedField(string propertyName);
        public void Dump();
    }
}