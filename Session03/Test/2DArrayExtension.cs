using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public static class _2DArrayExtension
    {
        public static int GetRowCount<T>(this T[,] array)
        {
            return array.GetLength(0);
        }

        public static int GetColumnCount<T>(this T[,] array)
        {
            return array.GetLength(1);
        }

        public static void Sort<T>(this T[,] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.GetRowCount() * array.GetColumnCount(); i++)
            {
                int minIndex = array.FindMinIndex<T>(i);
                if (minIndex != i)
                {
                    array.Swap(i, minIndex);
                }
            }
        }

        public static void SortBySelectedField<T>(this T[,] array) where T : IComparable<T>, IComparableInSeveralWay
        {
            int index = 0;
            Console.WriteLine("Sort By ?\n");
            for (int i = 1; i <= array[0,0].GetPropertyCount(); i++)
            {
                Console.WriteLine($"{i}: {array[0, 0].GetPropertyTitle(i)}");
            }
            index = Convert.ToInt32(Console.ReadLine());
            array.SetFieldIndexToCompare(index);
            array.Sort();
        }

        public static T GetObject<T>(this T[,] array, int index)
        {
            return array[index / array.GetColumnCount(), index % array.GetColumnCount()];
        }

        public static void SetObject<T>(this T[,] array, int index, T obj)
        {
            array[index / array.GetColumnCount(), index % array.GetColumnCount()] = obj;
        }

        public static int FindMinIndex<T>(this T[,] array, int startIndex) where T : IComparable<T>
        {
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);

            T min = GetObject(array, startIndex);
            int minIndex = startIndex;

            for (int i = startIndex + 1; i < rowCount * columnCount; i++)
            {
                if (GetObject(array, i).CompareTo(min) < 0)
                {
                    min = GetObject(array, i);
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public static void Swap<T>(this T[,] array, int i1, int i2)
        {
            T temp = GetObject(array, i1);
            SetObject(array, i1, GetObject(array, i2));
            SetObject(array, i2, temp);
        }

        public static void DumpArray<T>(this T[,] array) where T : IComparable<T>
        {
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);
            for (int i = 0; i < rowCount * columnCount; i++)
            {
                if (i % columnCount == 0)
                {
                    Console.Write("\n");
                }

                Console.Write(GetObject(array, i).ToString() + " ");
            }
            Console.WriteLine("\n");
        }

        public static void SetFieldIndexToCompare<T>(this T[,] array, int index) where T : IComparableInSeveralWay
        {
            array[0,0].SetPropertyIndexToCompare(index);
        }
    }
}
