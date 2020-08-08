using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public interface IComparableInSeveralWay
    {
        public static int PropertyIndexToCompare { get; set; }
        public static Dictionary<int, string> PropertyMappingDictionary { get; set;}
        public void SetPropertyIndexToCompare(int index);
        public int GetPropertyCount();
        public string GetPropertyTitle(int index);
    }
}
