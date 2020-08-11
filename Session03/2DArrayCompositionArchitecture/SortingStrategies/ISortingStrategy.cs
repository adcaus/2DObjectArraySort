using System.Collections.Generic;

namespace _2DArrayCompositionArchitecture.SortingStrategies
{
    public interface ISortingStrategy<T>
    {
        public void SortBySelectedField(string propertyName);
        public void Dump();
    }
}