using System;
using System.Collections.Generic;

namespace _2DArrayCompositionArchitecture
{
    /// <summary>
    /// Defines a set of properties which can be used for sorting and methods for the selection of the property.
    /// </summary>
    public interface IComparableWithProperties
    {
        List<IComparable> UsedPropertyValueArray { get; set; }
        Dictionary<string, string> AvailableProperties { get; set; }
        public void SetPropertyIndexToCompare(int index);
        public int GetUsedPropertyCount();
        public string GetPropertyTitle(int index);
        public void RegisterProperties(bool isFirstElement);
    }
}
