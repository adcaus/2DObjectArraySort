using System;
using System.Collections.Generic;
using System.Linq;

namespace _2DArraySearch
{
    public class BinarySearch2D<T>
    {
        public readonly struct Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get; }
            public int Y { get; }
        }

        public Point BinarySearch(T [,] array, string sortProperty, object searchValue)
        {
            var flatArrayDictionary = Flatten(array);
            var sortedDictionary = Sort(flatArrayDictionary, sortProperty);
            KeyValuePair<Point, T>[] keyValuePairs = new KeyValuePair<Point, T>[sortedDictionary.Count];

            var index = 0;
            foreach (var item in sortedDictionary)
            {
                keyValuePairs[index] = item;
                index++;
            }

            var indexFound = BinarySearch(sortedDictionary, sortProperty, searchValue);
            return keyValuePairs[indexFound].Key;
        }

        private static Dictionary<Point, T> Flatten(T[,] array)
        {
            var dictionary = new Dictionary<Point, T>();

            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    dictionary.Add(new Point(i, j), array[i, j]);
                }
            }

            return dictionary;
        }

        private static Dictionary<Point, T> Sort(Dictionary<Point, T> dic, string sortProperty)
        {
            return dic.OrderBy(x => x.Value.GetReflectedPropertyValue(sortProperty)).ToDictionary(x => x.Key, x => x.Value);
        }

        private static int BinarySearch(Dictionary<Point, T> dic, string sortProperty, object target)
        {
            var inputArray = dic.Values.ToArray();

            var searchType = target.GetReflectedPropertyValue(sortProperty);

            int min = 0;
            int max = inputArray.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (searchType.Equals(inputArray[mid].GetReflectedPropertyValue(sortProperty)))
                {
                    return mid;
                }
                else if (searchType.CompareTo(inputArray[mid].GetReflectedPropertyValue(sortProperty)) < 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return -1;
        }
    }

    public static class Extensions
    {
        public static IComparable GetReflectedPropertyValue<T>(this T subject, string field)
        {
            if (String.IsNullOrWhiteSpace(field))
            {
                throw new ArgumentException($"{field} Is Not A Valid Property!");
            }

            object reflectedValue = subject.GetType().GetProperty(field).GetValue(subject, null);
            var type = (IComparable) reflectedValue;
            return type;
        }
    }
}