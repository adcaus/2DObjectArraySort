namespace _2DObjectArrayLibrary
{
    public interface ICustomComparer<T>
    {
        public int Compare(int a, int b);
        public T GetObject(int a);
        public T SetObject(int b, T obj);
    }
}