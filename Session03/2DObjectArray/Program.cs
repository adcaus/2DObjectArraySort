using System;
using _2DObjectArrayLibrary;

namespace _2DObjectArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] nArray = {
            //    { 8, 2, 10},
            //    { 1, 3, 2 },
            //    { 5, 4, 6 },
            //    { -2, 0, 3}
            //};

            //string[,] sArray = {
            //    { "Hello", "World" },
            //    { "ABCDE", "abced" },
            //    { "aBcDe", "abcde"}
            //};

            FruitsBasket[,] fArray = {
                { new FruitsBasket("Orange", new DateTime(2020, 7, 21)), new FruitsBasket("Apple", new DateTime(2020, 8, 1)) },
                { new FruitsBasket("Grape", new DateTime(2020, 6, 30)), new FruitsBasket("Lemon", new DateTime(2020, 8, 15)) }
            };

            Country[,] cArray = {
                { new Country("US", 331, 87_265_226), new Country("Japan", 126, 5_154_475), new Country("Australia", 25, 1_376_255)},
                { new Country("China", 1_439, 14_140_163), new Country("Spain", 46, 1_397_870), new Country("India", 1_380, 2_935_570)}
            };

            //nArray.Dump();
            //// "Sort" can be called by any array of classes / data types which implement "IComparable" interface
            //nArray.Sort();
            //nArray.Dump();

            //sArray.Dump();
            //sArray.Sort();
            //sArray.Dump();

            fArray.Dump();
            // "SortBySelectedField" can be called only by array of classes which implement "IComparableSeveralWays" interface
            fArray.SortBySelectedField();
            fArray.Dump();

            cArray.Dump();
            cArray.SortBySelectedField();
            cArray.Dump();
        }
    }
}
