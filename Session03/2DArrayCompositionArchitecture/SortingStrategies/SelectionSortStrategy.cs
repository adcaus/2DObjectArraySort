using System;

namespace _2DArrayCompositionArchitecture.SortingStrategies
{
    /// <summary>
    /// Shotaro's implementation of a 2D Selection Sort Implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectionSortStrategy<T> : SortingBaseTemplateClass<T> where T : IComparableWithProperties, IComparable<T>
    {
        public SelectionSortStrategy(T[,] objectArray) : base(objectArray) { }

        protected override void Sort()
        {
            for (int i = 0; i < GetRowCount() * GetColumnCount(); i++)
            {
                int minIndex = FindMinIndex(i);
                if (minIndex != i)
                {
                    Swap(minIndex, i);
                }
            }
        }

        private int FindMinIndex(int startIndex)
        {
            int rowCount = ObjectArray.GetLength(0);
            int columnCount = ObjectArray.GetLength(1);

            T min = GetObject(startIndex);
            int minIndex = startIndex;

            for (int i = startIndex + 1; i < rowCount * columnCount; i++)
            {
                if (Compare(startIndex, i) < 0)
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}