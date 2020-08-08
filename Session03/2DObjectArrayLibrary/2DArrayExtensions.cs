using System;

namespace _2DObjectArrayLibrary
{
    public static class _2DArrayExtensions
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
            /* SELECTION SORT */
            //for (int i = 0; i < array.GetRowCount() * array.GetColumnCount(); i++)
            //{
            //    int minIndex = array.FindMinIndex<T>(i);
            //    if (minIndex != i)
            //    {
            //        array.Swap(i, minIndex);
            //    }
            //}

            /* QUICK SORT */
            array.QuickSort(0, array.GetRowCount() * array.GetColumnCount() - 1);
        }

        public static void SortBySelectedField<T>(this T[,] array) where T : IComparable<T>, IComparableWithProperties
        {
            for (int i = 0; i < array.GetRowCount() * array.GetColumnCount(); i++)
            {
                array.GetObject(i).RegisterProperties(i == 0);
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
                for (int i = 0; i < array[0, 0].GetUsedPropertyCount(); i++)
                {
                    Console.WriteLine($"{i + 1}: {array[0, 0].GetPropertyTitle(i)}");
                }
                Console.WriteLine();

                sIndex = Console.ReadLine();
            } while (!Validate(sIndex, array[0, 0].GetUsedPropertyCount(), ref isInvalid));

            index = Convert.ToInt32(sIndex);
            array.SetFieldIndexToCompare(index - 1);
            array.Sort();
        }

        private static bool Validate(string s, int max, ref bool isInvalid)
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

        private static void QuickSort<T>(this T[,] array, int left, int right) where T : IComparable<T>
        {
            if (left < right)
            {
                int pi = array.Partition(left, right);
                array.QuickSort(left, pi - 1);
                array.QuickSort(pi + 1, right);
            }
        }

        private static int Partition<T>(this T[,] array, int left, int right) where T : IComparable<T>
        {
            int store = left;

            for (int i = left; i < right; i++)
            {
                if (array.Compare(i, right) <= 0)
                {
                    array.Swap(i, store);
                    store++;
                }
            }

            array.Swap(store, right);

            return store;
        }

        public static T GetObject<T>(this T[,] array, int index)
        {
            return array[index / array.GetColumnCount(), index % array.GetColumnCount()];
        }

        public static void SetObject<T>(this T[,] array, int index, T obj)
        {
            array[index / array.GetColumnCount(), index % array.GetColumnCount()] = obj;
        }

        //private static int FindMinIndex<T>(this T[,] array, int startIndex) where T : IComparable<T>
        //{
        //    int rowCount = array.GetLength(0);
        //    int columnCount = array.GetLength(1);

        //    T min = GetObject(array, startIndex);
        //    int minIndex = startIndex;

        //    for (int i = startIndex + 1; i < rowCount * columnCount; i++)
        //    {
        //        if (GetObject(array, i).CompareTo(min) < 0)
        //        {
        //            min = GetObject(array, i);
        //            minIndex = i;
        //        }
        //    }

        //    return minIndex;
        //}

        private static void Swap<T>(this T[,] array, int i1, int i2)
        {
            T temp = GetObject(array, i1);
            SetObject(array, i1, GetObject(array, i2));
            SetObject(array, i2, temp);
        }

        /// <summary>
        /// Displays the contents of a 2-dimensional array based on the "ToString" method of elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void Dump<T>(this T[,] array) where T : IComparable<T>
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

        public static void SetFieldIndexToCompare<T>(this T[,] array, int index) where T : IComparableWithProperties
        {
            array[0, 0].SetPropertyIndexToCompare(index);
        }

        private static int Compare<T>(this T[,] array, int i1, int i2) where T : IComparable<T>
        {
            return array.GetObject(i1).CompareTo(array.GetObject(i2));
        }
    }
}
