using System;
using System.Collections;
using System.Collections.Generic;

namespace _2DArrayCompositionArchitecture.SortingStrategies
{
    public abstract class SortingBaseTemplateClass<T> : ISortingStrategy<T> where T : IComparableWithProperties, IComparable<T>
    {
        protected T[,] ObjectArray { get; }
        private ConfigureComparer<T> Comparer { get; }

        protected SortingBaseTemplateClass(T[,] objectArray)
        {
            ObjectArray = objectArray;
            Comparer = new ConfigureComparer<T>(ObjectArray);
            //Comparer.SortBySelectedField(propertyName);
        }

        protected abstract void Sort();

        public void SortBySelectedField(string propertyName)
        {
            Comparer.SortBySelectedField(propertyName);
            Sort();
        }

        protected int GetRowCount()
        {
            return ObjectArray.GetLength(0);
        }

        protected int GetColumnCount()
        {
            return ObjectArray.GetLength(1);
        }

        protected T GetObject(int index)
        {
            return ObjectArray[index / GetColumnCount(), index % GetColumnCount()];
        }

        protected T SetObject(int index, T obj)
        {
            return ObjectArray[index / GetColumnCount(), index % GetColumnCount()] = obj;
        }

        protected void Swap(int i1, int i2)
        {
            T temp = GetObject(i1);
            SetObject(i1, GetObject(i2));
            SetObject(i2, temp);
        }

        protected int Compare(int i1, int i2)
        {
            return GetObject(i1).CompareTo(GetObject(i2));
        }

        /// <summary>
        /// Displays the contents of a 2-dimensional objectArray based on the "ToString" method of elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public virtual void Dump()
        {
            int rowCount = ObjectArray.GetLength(0);
            int columnCount = ObjectArray.GetLength(1);
            for (int i = 0; i < rowCount * columnCount; i++)
            {
                Console.Write(GetObject(i));
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
    }
}