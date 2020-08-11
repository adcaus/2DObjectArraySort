using System;
using System.Collections.Generic;
using System.Text;
using _2DObjectArrayLibrary.SortingStrategies;

namespace _2DObjectArrayLibrary
{
    //I replaced the static methods you were exposing with these two methods which also create a new instance of the class.  
    //The static methods although powerful have two major issues.
    //1. They are always public which means they can be called by anyone and expose the external state of the objects they extend (if not designed carefully)
    //2. They are static which means state becomes an issue.  Ideally they should be used on utilities where the state of the object does not matter
    //(Eg: whether lists and values have been initialized into a working state). 

    //These new extension methods mix the power of static extension for the user with the ease and safety of a class where the state can be more
    //easily guaranteed.  Plus now all the methods are private except for the ones the end user need to deal with
    //This means people cant reach their dirty fingers into the internal state of the object an screw things up haha (Encapsulation - Information Hiding)
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
