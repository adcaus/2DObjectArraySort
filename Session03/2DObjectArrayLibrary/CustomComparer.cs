using System;
using System.Collections.Generic;
using System.Text;
using _2DObjectArrayLibrary.SortingStrategies;

namespace _2DObjectArrayLibrary
{
    public static class StaticExt
    {
        public static void SortBySelection<T>(this T[,] inputArray) where T : IComparable<T>, IComparableWithProperties
        {
            var arrayIn = new CustomComparer<T>(inputArray);
            arrayIn.SortBySelectedField(inputArray);
        }

        public static void DumpArray<T>(this T[,] inputArray) where T : IComparable<T>, IComparableWithProperties
        {
            var arrayIn = new CustomComparer<T>(inputArray);
            arrayIn.Dump(inputArray);
        }
    }

    public class CustomComparer<T> : ICustomComparer<T> where T : IComparable<T> , IComparableWithProperties
    {
        private T[,] Array { get; set; }

        public ISortingStrategy<T> SortingStrategy { get; set; }

        public CustomComparer(T[,] array)
        {
            SortingStrategy = new SelectionSortStrategy<T>(this);
            Array = array;
        }

        private int GetRowCount()
        {
            return Array.GetLength(0);
        }

        private int GetColumnCount()
        {
            return Array.GetLength(1);
        }

        //Sort
        private void Sort()
        {
            SortingStrategy.Sort(Array);
        }

        public void SortBySelectedField(T[,] arrayToSort)
        {
            for (int i = 0; i < GetRowCount() * GetColumnCount(); i++)
            {
                GetObject(i).RegisterProperties(i == 0);
            }

            string sIndex;
            int index;
            bool isInvalid = false;

            do
            {
                if (isInvalid)
                {
                    Console.WriteLine("\n******************\nINVALID INPUT\n******************\n");
                }

                Console.WriteLine("Sort By ?\n");
                for (int i = 0; i < Array[0, 0].GetUsedPropertyCount(); i++)
                {
                    Console.WriteLine($"{i + 1}: {Array[0, 0].GetPropertyTitle(i)}");
                }
                Console.WriteLine();

                sIndex = Console.ReadLine();
            } while (!Validate(sIndex, Array[0, 0].GetUsedPropertyCount(), ref isInvalid));

            index = Convert.ToInt32(sIndex);
            SetFieldIndexToCompare(index - 1);
            Sort();
        }

        private bool Validate(string s, int max, ref bool isInvalid)
        {
            int n = 0;

            try
            {
                n = Convert.ToInt32(s);
            }
            catch (Exception)
            {
                isInvalid = true;
                return false;
            }

            if (n <= 0 || n > max)
            {
                isInvalid = true;
                return false;
            }

            isInvalid = false;

            return true;
        }

        public T GetObject(int index)
        {
            return Array[index / GetColumnCount(), index % GetColumnCount()];
        }

        public T SetObject(int index, T obj)
        {
            return Array[index / GetColumnCount(), index % GetColumnCount()] = obj;
        }

        /// <summary>
        /// Displays the contents of a 2-dimensional array based on the "ToString" method of elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public void Dump(T[,] array)
        {
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);
            for (int i = 0; i < rowCount * columnCount; i++)
            {
                if (i % columnCount == 0)
                {
                    Console.Write("\n");
                }

                Console.Write(GetObject(i).ToString() + " ");
            }
            Console.WriteLine("\n");
        }

        private void SetFieldIndexToCompare(int index)
        {
            Array[0, 0].SetPropertyIndexToCompare(index);
        }

        public int Compare(int i1, int i2)
        {
            return GetObject(i1).CompareTo(GetObject(i2));
        }
    }
}
