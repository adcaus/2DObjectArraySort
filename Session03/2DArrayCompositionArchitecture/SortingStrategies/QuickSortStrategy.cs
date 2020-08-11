using System;

namespace _2DArrayCompositionArchitecture.SortingStrategies
{
    /// <summary>
    /// Shotaro's Implementation of a 2D array quick sort method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSortStrategy<T> : SortingBaseTemplateClass<T> where T : IComparableWithProperties, IComparable<T>
    {
        public QuickSortStrategy(T[,] objectArray) : base(objectArray){}

        protected override void Sort()
        {
            QuickSort(0, GetRowCount() * GetColumnCount() - 1);
        }

        private void QuickSort(int left, int right)
        {
            if (left < right)
            {
                int pi = Partition(left, right);
                QuickSort(left, pi - 1);
                QuickSort(pi + 1, right);
            }
        }

        private int Partition(int left, int right)
        {
            int store = left;

            for (int i = left; i < right; i++)
            {
                if (Compare(i, right) <= 0)
                {
                    Swap(i, store);
                    store++;
                }
            }

            Swap(store, right);

            return store;
        }
    }
}