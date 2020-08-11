using System;
using System.Collections;
using System.Collections.Generic;

namespace _2DArrayCompositionArchitecture.SortingStrategies
{
    //This class is making use of a Template Method Pattern.  This is a great way to implement different algorithms/implementations
    //But keep control of the order in which inheriting classes methods are called.  With a template method we can also indicate to
    //Other developers what they need to do to create an implementation of a sorting algorithm by providing hooks for them to override.
    //Abstract Methods are methods that the inheriting class MUST provide an implementation for
    //Virtual Methods are methods that the user can OPTIONALLY provide an implementation for (or extend by calling base)
    //Normal Methods are methods that the user cannot access and are dictated by the base class
    //https://sourcemaking.com/design_patterns/template_method
    public abstract class SortingBaseTemplateClass<T> : ISortingStrategy<T> where T : IComparableWithProperties, IComparable<T>
    {
        protected T[,] ObjectArray { get; }
        private ConfigureComparer<T> Comparer { get; }

        protected SortingBaseTemplateClass(T[,] objectArray)
        {
            ObjectArray = objectArray;
            Comparer = new ConfigureComparer<T>(ObjectArray);
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