namespace _2DObjectArrayLibrary.SortingStrategies
{
    public class QuickSortStrategy<T> : ISortingStrategy<T>
    {
        public ICustomComparer<T> CustomComparer { get; set; }

        public T[,] Array { get; set; }

        public QuickSortStrategy(ICustomComparer<T> customComparer)
        {
            CustomComparer = customComparer;
        }

        public void Sort(T[,] array)
        {
            Array = array;
            QuickSort(0, GetRowCount() * GetColumnCount() - 1);
        }

        private int GetRowCount()
        {
            return Array.GetLength(0);
        }

        private int GetColumnCount()
        {
            return Array.GetLength(1);
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
                if (CustomComparer.Compare(i, right) <= 0)
                {
                    Swap(i, store);
                    store++;
                }
            }

            Swap(store, right);

            return store;
        }

        private void Swap(int i1, int i2)
        {
            T temp = CustomComparer.GetObject(i1);
            CustomComparer.SetObject(i1, CustomComparer.GetObject(i2));
            CustomComparer.SetObject(i2, temp);
        }
    }
}