using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public abstract class BaseComparableClass : IComparableInSeveralWay
    {
        public static int PropertyIndexToCompare { get; set; }
        public static Dictionary<int, string> PropertyMappingDictionary { get; set; }

        public void SetPropertyIndexToCompare(int index)
        {
            PropertyIndexToCompare = index;
        }

        public int GetPropertyCount()
        {
            return PropertyMappingDictionary.Count;
        }

        public string GetPropertyTitle(int index)
        {
            return PropertyMappingDictionary[index];
        }
    }
}
