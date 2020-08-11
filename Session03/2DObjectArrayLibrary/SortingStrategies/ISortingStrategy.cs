namespace _2DObjectArrayLibrary.SortingStrategies
{
    public interface ISortingStrategy<T>
    {
        public void Sort(T[,] array);
    }
}