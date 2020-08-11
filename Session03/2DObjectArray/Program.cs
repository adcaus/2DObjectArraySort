using System;
using _2DObjectArrayLibrary;

namespace _2DObjectArray
{
    class Program
    {
        static void Main(string[] args)
        {
            FruitsBasket[,] fArray = {
                { new FruitsBasket("Orange", new DateTime(2020, 7, 21), "ATest1"), new FruitsBasket("Apple", new DateTime(2020, 8, 1), "BTest1") },
                { new FruitsBasket("Grape", new DateTime(2020, 6, 30), "CTest1"), new FruitsBasket("Lemon", new DateTime(2020, 8, 15), "DTest1") }
            };

            Country[,] cArray = {
                { new Country("US", 331, 87_265_226), new Country("Japan", 126, 5_154_475), new Country("Australia", 25, 1_376_255)},
                { new Country("China", 1_439, 14_140_163), new Country("Spain", 46, 1_397_870), new Country("India", 1_380, 2_935_570)}
            };

            fArray.DumpArray();
            fArray.SortBySelection();
            fArray.DumpArray();

            cArray.DumpArray();
            cArray.SortBySelection();
            cArray.DumpArray();
        }
    }
}
