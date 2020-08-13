using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _2DArraySearchTests
{
    public class TestNestedClass : IComparable
    {
        public TestNestedClass(string theName)
        {
            TheName = theName;
        }

        public string TheName { get; set; }
        public int CompareTo(object? obj)
        {
            return this.TheName.CompareTo(((TestNestedClass)obj).TheName);
        }
    }
}
