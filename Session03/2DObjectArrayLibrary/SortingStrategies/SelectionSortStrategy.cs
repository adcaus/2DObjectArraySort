namespace _2DObjectArrayLibrary.SortingStrategies
{
    public class SelectionSortStrategy<T> : ISortingStrategy<T>
    {
        public ICustomComparer<T> CustomComparer { get; set; }

        public T[,] Array { get; set; }

        public SelectionSortStrategy(ICustomComparer<T> customComparer)
        {
            CustomComparer = customComparer;
        }

        private int GetRowCount()
        {
            return Array.GetLength(0);
        }

        private int GetColumnCount()
        {
            return Array.GetLength(1);
        }

        public void Sort(T[,] array)
        {
            Array = array;
            for (int i = 0; i < GetRowCount() * GetColumnCount(); i++)
            {
                int minIndex = FindMinIndex(i);
                if (minIndex != i)
                {
                    Swap(i, minIndex);
                }
            }
        }

        private int FindMinIndex(int startIndex)
        {
            int rowCount = Array.GetLength(0);
            int columnCount = Array.GetLength(1);

            T min = CustomComparer.GetObject(startIndex);
            int minIndex = startIndex;

            for (int i = startIndex + 1; i < rowCount * columnCount; i++)
            {
                if (CustomComparer.Compare(startIndex, i) < 0)
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private void Swap(int i1, int i2)
        {
            T temp = CustomComparer.GetObject(i1);
            CustomComparer.SetObject(i1, CustomComparer.GetObject(i2));
            CustomComparer.SetObject(i2, temp);
        }
    }
}